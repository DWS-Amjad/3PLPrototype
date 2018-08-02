using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DAL.Models;
using DAL;
using ValidationRuleEngine.Interfaces;
using Newtonsoft.Json;
using ValidationRuleEngine.Configuration;
using System.Xml.Serialization;

namespace ValidationRuleEngine.Implementations
{
    public class ValidatorEngine : IEngine
    {
        private ValidationRuleEngine.Configuration.Config config = new ValidationRuleEngine.Configuration.Config();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xDoc"></param>
        public ValidatorEngine(XDocument xDoc)
        {
            try
            {
                ApplicationMaster objApplicationMaster = unitOfWork.ApplicationMasterRepository
                .SelectByID(Constants.ApplicationId);

                //TODO  validate the rule xml using the xsd

                Helper.XMLManagement<ValidationRuleEngine.Configuration.ConfigurationStore>.Instance
                    .UnMarshalingFromXML(objApplicationMaster.ConfigFilePath, out configurationStore);
                /*--------------------*/

                this.ConfigXmlDocument = XDocument.Load(objApplicationMaster.ConfigFilePath);
                this.config = configurationStore.Items[0];
                this.CurrentXmlDocument = xDoc;//XDocument.Load(this.config.source_file_path);
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// This method populates rule objects
        /// </summary>
        private void configureValidator()
        {
            try
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
                        (rulesElement.Attribute(XName.Get("enabled")) == null)
                            ? false : Convert.ToBoolean(rulesElement.Attribute(XName.Get("enabled")).Value));

                    var validationElements = rulesElement.Element(XName.Get("validations"))
                        .Elements(XName.Get("validation"));

                    if (validationElements != null && validationElements.Any())
                    {
                        var validationList = new List<IValidation>();
                        foreach (var validationElement in validationElements)
                        {
                            Type elementType = Type.GetType(validationElement.Attribute(XName.Get("type")).Value);
                            Validation newValidation = (Validation)Activator.CreateInstance(elementType,
                                validationElement.Attribute(XName.Get("name")).Value,
                                validationElement.Attribute(XName.Get("validator_type")).Value, 
                                (validationElement.Attribute(XName.Get("enabled")) != null) ? Convert.ToBoolean(validationElement.Attribute(XName.Get("enabled")).Value)
                                : false,
                                (validationElement.Attribute(XName.Get("on_failure_halt")) != null) ? Convert.ToBoolean(validationElement.Attribute(XName.Get("on_failure_halt")).Value)
                                : false);
                            
                            //newValidation.Name = validationElement.Attribute(XName.Get("name")).Value;
                            //newValidation.onFailureHalt = ;
                            //newValidation.validator_type = ;
                            //newValidation.enabled = ;
                            //newValidation.currentXml = this.CurrentXmlDocument;

                            var attributeElements = validationElement.Element(XName.Get("attributes"))
                                .Elements(XName.Get("attribute"));
                            if (attributeElements != null && attributeElements.Any())
                            {
                                var attributeList = new List<ValidationRuleEngine.Configuration.Attribute>();
                                
                                foreach (var attributeElement in attributeElements)
                                {
                                    ValidationRuleEngine.Configuration.Attribute newAttribute = new Configuration.Attribute();

                                    var serializer = new XmlSerializer(typeof(ValidationRuleEngine.Configuration.Attribute));
                                    newAttribute = (ValidationRuleEngine.Configuration.Attribute)serializer.Deserialize(attributeElement.CreateReader());

                                    attributeList.Add(newAttribute);
                                }
                                newValidation.LocalAttributes = attributeList;
                            }
                            
                            var valActionElements = rulesElement.Element(XName.Get("actions"))
                                                .Elements(XName.Get("action"));

                            if (valActionElements != null && valActionElements.Any())
                            {
                                var actionList = new List<IAction>();
                                foreach (var valActionElement in valActionElements)
                                {
                                    actionList.Add(Helper.XMLManagement<Action>.Instance.GetInstance<IAction>(valActionElement));
                                }

                                newValidation.Actions = actionList;
                            }

                            newValidation.LoadGlobalAttributeValues(config.attributes, this.CurrentXmlDocument);
                            validationList.Add(newValidation);
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
                            actionList.Add(Helper.XMLManagement<Action>.Instance.GetInstance<IAction>(actionElement));
                        }

                        newRule.Actions = actionList;

                    }
                    ruleList.Add(newRule);
                }

                this.Rules = ruleList;
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
        }

        //private bool validateConfigFile()
        //{

        //}

        /// <summary>
        /// 
        /// </summary>
        public void Configure()
        {
            try
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
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
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
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
            return (retVal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean Validation()
        {
            Boolean retVal = false;
            try
            {
                this.Configure();
                retVal = this.StartValidation();
                this.Stop();
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
            
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
                bool allValidationSuccessful = true;
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
                                    Console.WriteLine("validation rule succeed. Now executing (executeOn==success) actions");
                                    validation.Actions.Where(act => act.enabled && act.executeOn.Equals(Constants.ExecuteOn.success))
                                        .All(act => act.Execute(null).Equals(true));
                                }
                                else
                                {
                                    allValidationSuccessful = false;
                                    retVal = false;
                                    onFailureHalt = validation.onFailureHalt;
                                    Console.WriteLine("validation rule failed. Now executing (executeOn==failure) actions");
                                    validation.Actions.Where(act => act.enabled && act.executeOn.Equals(Constants.ExecuteOn.failure))
                                    .All(act => act.Execute(null).Equals(true));
                                }
                            }
                        }
                        if (allValidationSuccessful)
                        {
                            Console.WriteLine("All configured validation rules succeed. Now executing (executeOn==success) actions");
                            rule.Actions.Where(act => act.enabled && act.executeOn.Equals(Constants.ExecuteOn.success))
                                .All(act => act.Execute(null).Equals(true));
                        }
                        else
                        {
                            Console.WriteLine("one of the configured validation rules failed. Now executing (executeOn==failure) actions");
                            rule.Actions.Where(act => act.enabled && act.executeOn.Equals(Constants.ExecuteOn.failure))
                                    .All(act => act.Execute(null).Equals(true));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
            return retVal;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <param name="currentElement"></param>
        /// <returns></returns>
        public static IValidationContext GetContext(XDocument xmlDocument, XElement currentElement)
        {
            if (xmlDocument == null && currentElement == null)
            {
                return new ValidationContext(null, null, null);
            }

            XElement Element = xmlDocument.Root.Descendants(currentElement.Name)
                .SingleOrDefault(x => x.Value.Equals(currentElement.Value, StringComparison.InvariantCulture));
            XElement parentElement = Element != null ? Element.Parent : null;

            return new ValidationContext(xmlDocument, parentElement, currentElement);
        }

        /// <summary>
        /// 
        /// </summary>
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
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
        }
    }
}


