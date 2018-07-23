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

namespace ValidationRuleEngine.Implementations
{
    public class ValidatorEngine : IEngine
    {
        private Config config = new Config();
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
        
        private ConfigurationStore configurationStore = new ConfigurationStore();
        public IEnumerable<IRule> Rules
        {
            get;
            private set;
        }

        #region RepositoryObjectDeclaration
            UnitOfWork unitOfWork = new UnitOfWork();
        #endregion

        public ValidatorEngine()
        {
            ApplicationMaster objApplicationMaster = unitOfWork.ApplicationMasterRepository.SelectByID(Constants.ApplicationId);
            Helper.XMLHelper<ConfigurationStore>.Instance.UnMarshalingFromXML(objApplicationMaster.ConfigFilePath, out configurationStore);
            /*--------------------*/

            this.ConfigXmlDocument = XDocument.Load(objApplicationMaster.ConfigFilePath);
            this.config = configurationStore.Items[0];
        }

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
                    (rulesElement.Attribute(XName.Get("name")) != null) ? rulesElement.Attribute(XName.Get("name")).Value : null,
                    (rulesElement.Element(XName.Get("path")) != null) ? rulesElement.Element(XName.Get("path")).Value : null,
                    (rulesElement.Attribute(XName.Get("enabled")) == null) ? false : Convert.ToBoolean(rulesElement.Attribute(XName.Get("enabled")).Value));

                var validationElements = rulesElement.Element(XName.Get("validations")).Elements(XName.Get("validation"));
                if (validationElements != null && validationElements.Any())
                {
                    var validationList = new List<IValidation>();
                    foreach (var validationElement in validationElements)
                    {
                        validationList.Add(this.GetInstance<IValidation>(validationElement));
                    }

                    newRule.Validations = validationList;
                }

                var actionElements = rulesElement.Element(XName.Get("actions")).Elements(XName.Get("action"));
                if (actionElements != null && actionElements.Any())
                {
                    var actionList = new List<IAction>();
                    foreach (var actionElement in actionElements)
                    {
                        actionList.Add(this.GetInstance<IAction>(actionElement));
                    }

                    newRule.Actions = actionList;
                }
                ruleList.Add(newRule);
            }

            this.Rules = ruleList;
            this.CurrentXmlDocument = XDocument.Load(this.config.source_file_path);
        }

        private TResult GetInstance<TResult>(XElement xElement)
        {
            XmlSerializer serializer = new XmlSerializer(Type.GetType(xElement.Attribute(XName.Get("type")).Value));
            using (TextReader reader = new StringReader(xElement.ToString()))
            {
                return (TResult)serializer.Deserialize(reader);
            }
        }

        private IValidationContext GetContext(XDocument xmlDocument, XElement currentElement)
        {
            if (xmlDocument == null && currentElement == null)
            {
                return new ValidationContext(null, null, null);
            }

            XElement Element = xmlDocument.Root.Descendants(currentElement.Name).SingleOrDefault(x =>
                x.Value.Equals(currentElement.Value, StringComparison.InvariantCulture))/*.Parent*/;
            XElement parentElement = Element!=null ? Element.Parent : null;
            
            return new ValidationContext(xmlDocument, parentElement, currentElement);
        }

        void IEngine.Configure()
        {   
            configureValidator();

            #region ApplicationLogEntries
                ApplicationLog objApplicationLog = new ApplicationLog();
            
                objApplicationLog.Id = Guid.NewGuid();
                objApplicationLog.Message = "LoremIpsumMessage";
                objApplicationLog.TimeStamp = DateTime.Now;
                objApplicationLog.UserId = "amjad.leghari";
                objApplicationLog.ApplicationMaster = unitOfWork.ApplicationMasterRepository.SelectByID(Constants.ApplicationId);
                objApplicationLog.ApplicationEventMaster = unitOfWork.ApplicationEventMasterRepository.SelectByID(Constants.EventType.Validation_Engine_Configured);
                unitOfWork.ApplicationLogRepository.Insert(objApplicationLog);
                unitOfWork.Save();
            #endregion
        }

        void IEngine.Start()
        {
            Console.WriteLine("Validation Start Routine ===>");

            StartValidator();
            
            #region ApplicationLogEntries
                ApplicationLog obj = new ApplicationLog();
                obj.Id = Guid.NewGuid();
                obj.Message = "LoremIpsumMessage";
                obj.TimeStamp = DateTime.Now;
                obj.UserId = "amjad.leghari";
                obj.ApplicationMaster = unitOfWork.ApplicationMasterRepository.SelectByID(Constants.ApplicationId);
                obj.ApplicationEventMaster = unitOfWork.ApplicationEventMasterRepository.SelectByID(Constants.EventType.Validation_Engine_Started);
                unitOfWork.ApplicationLogRepository.Insert(obj);
                unitOfWork.Save();
            #endregion

            Console.WriteLine("<=== Validation Start routine ended.");
        }

        private void StartValidator()
        {
            foreach (var rule in Rules)
            {
                if(rule.Enabled)
                {
                    if (!String.IsNullOrEmpty(rule.Xpath))
                    {
                        XPathDocument xPathDoc = new XPathDocument(this.CurrentXmlDocument.Root.CreateReader(/*ReaderOptions.OmitDuplicateNamespaces*/));
                        var xpatheNavigator = xPathDoc.CreateNavigator();
                        var matchingNodes = xpatheNavigator.Select(rule.Xpath);
                        if (matchingNodes == null || matchingNodes.Count == 0)
                        {
                            Console.WriteLine("No matching element found for rule {0}", rule.Name);
                            continue;
                        }

                        Console.WriteLine("{0} matching nodes found for XPath {1}.", matchingNodes.Count, rule.Xpath);

                        while (matchingNodes.MoveNext())
                        {
                            var currentXElement = XElement.Parse(matchingNodes.Current.OuterXml);

                            Console.WriteLine("Executing validations for following xml Node.");
                            Console.WriteLine(currentXElement.ToString());

                            var context = this.GetContext(this.CurrentXmlDocument, currentXElement);
                            if (rule.Validations.Where(val => val.enabled)
                                .All(val => val.Validate(context, this.CurrentXmlDocument, config.document_type, config.order_number_path, config.order_date_path).Equals(true)))
                            {
                                Console.WriteLine("All configured validation rules succeed. Now executing actions");
                                rule.Actions.All(act => act.Execute(context).Equals(true));
                            }
                        }
                    }
                    else
                    {
                        IValidationContext context = new ValidationContext(null, null, null);
                        
                        if (rule.Validations.All(val => val.Validate(null, this.CurrentXmlDocument, config.document_type, config.order_number_path, config.order_date_path).Equals(true)))
                        {
                            Console.WriteLine("All configured validation rules succeed. Now executing actions");
                            rule.Actions.Where(act => act.executeOn.Equals(Constants.ExecuteOn.success))
                                .All(act => act.Execute(context).Equals(true));
                        }
                        else
                        {
                            Console.WriteLine("All configured validation rules failed. Now executing actions");
                            rule.Actions.Where(act => act.executeOn.Equals(Constants.ExecuteOn.failure))
                                .All(act => act.Execute(context).Equals(true));
                        }
                    }
                }
            }
        }
        
        void IEngine.Stop()
        {
            #region ApplicationLogEntries
                ApplicationLog obj = new ApplicationLog();
                obj.Id = Guid.NewGuid();
                obj.Message = "LoremIpsumMessage";
                obj.TimeStamp = DateTime.Now;
                obj.UserId = "amjad.leghari";
                obj.ApplicationMaster = unitOfWork.ApplicationMasterRepository.SelectByID(Constants.ApplicationId);
                obj.ApplicationEventMaster = unitOfWork.ApplicationEventMasterRepository.SelectByID(Constants.EventType.Validation_Engine_Stopped);
                unitOfWork.ApplicationLogRepository.Insert(obj);
                unitOfWork.Save();
            #endregion
            this.unitOfWork.Dispose();
            this.Rules = null;
            this.ConfigXmlDocument = null;
            this.config = null;
        }
    }
}


