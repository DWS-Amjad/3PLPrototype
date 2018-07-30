using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DAL.Models;
using DAL;
using ValidationRuleEngine.Interfaces;
using System.Xml.Serialization;
using System.IO;
using System.Xml.XPath;
using ValidationRuleEngine.Helper;

namespace ValidationRuleEngine.Implementations
{
    public class ValidatorEngine : IEngine
    {
        private Config config = new Config();
        private ConfigurationStore configurationStore = new ConfigurationStore();

        public XDocument ConfigXmlDocument
        {
            get;
            private set;
        }
        public XDocument CurrentXmlDocument
        {
            get;
            private set;
        }
        
        
        public IEnumerable<IRule> Rules
        {
            get;
            private set;
        }

        #region RepositoryObjectDeclaration
            UnitOfWork unitOfWork = new UnitOfWork();
        #endregion

        public ValidatorEngine(XDocument xDoc)
        {
            try
            {
                ApplicationMaster objApplicationMaster = unitOfWork.ApplicationMasterRepository
                .SelectByID(Constants.ApplicationId);
                Helper.XMLHelper<ConfigurationStore>.Instance
                    .UnMarshalingFromXML(objApplicationMaster.ConfigFilePath, out configurationStore);
                /*--------------------*/

                this.ConfigXmlDocument = XDocument.Load(objApplicationMaster.ConfigFilePath);
                this.config = configurationStore.Items[0];
                this.CurrentXmlDocument = xDoc;//XDocument.Load(this.config.source_file_path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method populates rule objects
        /// </summary>
        private void configureValidator()
        {
            if (this.ConfigXmlDocument == null)
            {
                throw new Exception("Xml configurations not set.");
            }
            
            var ruleElements = this.ConfigXmlDocument.Element("ConfigurationStore").Elements("Config").ToList()[0].Elements("rules").Descendants("rule").ToList();
            
            if (ruleElements == null && ruleElements.Count == 0)
            {
                throw new Exception("No rules found...!!!");
            }

            var ruleList = new List<IRule>();

            foreach (var rulesElement in ruleElements)
            {
                var newRule = new ValidationRuleEngine.Implementations.Rule(
                    (rulesElement.Attribute(XName.Get("name")) != null) 
                        ? rulesElement.Attribute(XName.Get("name")).Value : null,
                    (rulesElement.Element(XName.Get("path")) != null) 
                        ? rulesElement.Element(XName.Get("path")).Value : null,
                    (rulesElement.Attribute(XName.Get("enabled")) == null) 
                        ? false : Convert.ToBoolean(rulesElement.Attribute(XName.Get("enabled")).Value));

                var validationElements = rulesElement.Element(XName.Get("validations"))
                    .Elements(XName.Get("validation"));

                if (validationElements != null && validationElements.Any())
                {
                    var validationList = new List<IValidation>();
                    foreach (var validationElement in validationElements)
                    {
                        var validation = XMLHelper<Validation>.Instance.GetInstance<IValidation>(validationElement);
                        validation.LoadGlobalAttributeValues(this.config.attributes, this.CurrentXmlDocument);
                        validationList.Add(validation);
                    }

                    newRule.Validations = validationList;
                }

                var actionElements = rulesElement.Element(XName.Get("actions"))
                    .Elements(XName.Get("action"));

                if (actionElements != null && actionElements.Any())
                {
                    var actionList = new List<IAction>();
                    foreach (var actionElement in actionElements)
                    {
                        actionList.Add(XMLHelper<Action>.Instance.GetInstance<IAction>(actionElement));
                    }

                    newRule.Actions = actionList;
                }
                ruleList.Add(newRule);
            }

            this.Rules = ruleList;
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Configure()
        {   
            configureValidator();

            #region ApplicationLogEntries
                ApplicationEventMaster Event = unitOfWork.ApplicationEventMasterRepository
                    .SelectByID(Constants.EventType.Validation_Engine_Configured);

                ApplicationMaster Application = unitOfWork.ApplicationMasterRepository
                    .SelectByID(Constants.ApplicationId);

                ApplicationLog objApplicationLog = unitOfWork
                    .CreateApplicationLogObject(Event, Application, "LoremIpsumMessage",
                    "amjad.leghari");

                unitOfWork.ApplicationLogRepository.Insert(objApplicationLog);
                unitOfWork.Save();
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean StartValidation()
        {
            Boolean retVal = false;
            try
            {
                Console.WriteLine("Validation StartValidation Routine ===>");

                retVal = StartValidator();

                #region ApplicationLogEntries
                    ApplicationEventMaster Event = unitOfWork.ApplicationEventMasterRepository
                        .SelectByID(Constants.EventType.Validation_Engine_Started);

                    ApplicationMaster application = unitOfWork.ApplicationMasterRepository
                        .SelectByID(Constants.ApplicationId);

                    ApplicationLog obj = unitOfWork.CreateApplicationLogObject(Event, application,
                        "LoremIpsumMessage", "amjad.leghari");

                    unitOfWork.ApplicationLogRepository.Insert(obj);
                    unitOfWork.Save();
                #endregion

                Console.WriteLine("<=== Validation StartValidation routine ended.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (retVal);
        }
        public Boolean Validation()
        {
            Boolean retVal = false;
            this.Configure();
            retVal = this.StartValidation();
            this.Stop();
            return retVal;
        }
        /// <summary>
        /// 
        /// </summary>
        private Boolean StartValidator()
        {
            bool retVal = false;
            try
            {
                bool onFailureHalt = false;
                foreach (var rule in Rules)
                {
                    if (rule.Enabled)
                    {
                        onFailureHalt = false;
                        foreach (var validation in rule.Validations)
                        {
                            if (validation.enabled && !onFailureHalt)
                            {
                                if (validation.Validate())
                                {
                                    onFailureHalt = false;
                                    Console.WriteLine("All configured validation rules succeed. Now executing (executeOn==success) actions");
                                    rule.Actions.Where(act => act.enabled && act.executeOn.Equals(Constants.ExecuteOn.success))
                                        .All(act => act.Execute(null/*context*/).Equals(true));
                                }
                                else
                                {
                                    retVal = false;
                                    onFailureHalt = validation.onFailureHalt;
                                    rule.Actions.Where(act => act.enabled && act.executeOn.Equals(Constants.ExecuteOn.failure))
                                    .All(act => act.Execute(null/*context*/).Equals(true));
                                }
                            }
                        }   
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }
        
        public void Stop()
        {
            try
            {
                #region ApplicationLogEntries
                ApplicationEventMaster Event = unitOfWork.ApplicationEventMasterRepository
                    .SelectByID(Constants.EventType.Validation_Engine_Stopped);

                ApplicationMaster Application = unitOfWork.ApplicationMasterRepository
                    .SelectByID(Constants.ApplicationId);

                ApplicationLog obj = unitOfWork.CreateApplicationLogObject(Event, Application,
                    "LoremIpsumMessage", "amjad.leghari");

                unitOfWork.ApplicationLogRepository.Insert(obj);
                unitOfWork.Save();
                #endregion
                this.unitOfWork.Dispose();
                this.Rules = null;
                this.ConfigXmlDocument = null;
                this.config = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


