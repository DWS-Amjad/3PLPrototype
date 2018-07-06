using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using ValidationRuleEngine.Interfaces;

namespace ValidationRuleEngine.Implementations
{
    public class CustomValidatorEngine : IEngine
    {        
        public XDocument ConfigXml
        {
            get;
            private set;
        }

        public IEnumerable<IRule> Rules
        {
            get;
            private set;
        }

        public CustomValidatorEngine(XDocument configXml)
        {
            ConfigXml = configXml;
        }

        /// <summary>
        /// Load configuration for rule engine
        /// </summary>
        public void Configure()
        {
            if (ConfigXml == null)
            {
                throw new Exception("Xml configurations not set.");
            }

            var ruleElements = ConfigXml.Root.Elements(XName.Get("rule")).ToList();

            if (ruleElements == null && ruleElements.Count == 0)
            {
                throw new Exception("No rules found...!!!");
            }

            var ruleList = new List<IRule>();

            foreach (var rulesElement in ruleElements)
            {
                var newRule = new ValidationRuleEngine.Implementations.Rule(rulesElement.Attribute(XName.Get("name")).Value, rulesElement.Element(XName.Get("path")).Value);
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
        }
                

        /// <summary>
        /// Executes rules and perform actions based on configuration
        /// </summary>
        /// <param name="xmlDocument">XML to validate</param>
        public void Start()
        {
            foreach (var rule in Rules)
            {

                XPathDocument xPathDoc = new XPathDocument(/*xmlDocument*/ConfigXml.Root.CreateReader(/*ReaderOptions.OmitDuplicateNamespaces*/));
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

                    //TODO: check the execution of failed validation and failed actions
                    //TODO: check the thread safty for validations should be executed on saperate threads
                    var context = this.GetContext(ConfigXml/*xmlDocument*/, currentXElement);
                    if (rule.Validations.All(val => val.Validate(context).Equals(true)))
                    {
                        Console.WriteLine("All configured validation rules succeed. Now executing actions");
                        rule.Actions.All(act => act.Execute(context).Equals(true));
                    }
                }
            }
        }

        public void Stop()
        {
            this.Rules = null;
            this.ConfigXml = null;
        }

        

        private IValidationContext GetContext(XDocument xmlDocument, XElement currentElement)
        {
            if (xmlDocument == null && currentElement == null)
            {
                return new ValidationContext(null, null, null);
            }

            XElement parentElement = xmlDocument.Root.Descendants(currentElement.Name).Single(x =>
                x.Value.Equals(currentElement.Value, StringComparison.InvariantCulture)).Parent;
            return new ValidationContext(xmlDocument, parentElement, currentElement);
        }

        private TResult GetInstance<TResult>(XElement xElement)
        {
            XmlSerializer serializer = new XmlSerializer(Type.GetType(xElement.Attribute(XName.Get("type")).Value));
            using (TextReader reader = new StringReader(xElement.ToString()))
            {
                return (TResult)serializer.Deserialize(reader);
            }
        }
    }
}
