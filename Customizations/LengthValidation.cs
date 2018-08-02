using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using ValidationRuleEngine;
using ValidationRuleEngine.Implementations;
using ValidationRuleEngine.Interfaces;

namespace Customizations
{
    [Serializable]
    [XmlRoot(ElementName = "validation")]
    public class LengthValidation : ValidationRuleEngine.Implementations.Validation
    {
        //#region Custom Properties

        //    [XmlElement("length")]
        //    public string Length { get; set; }

        //    [XmlElement("message")]
        //    public string Message { get; set; }

        //#endregion

        public LengthValidation()
        { }
        public LengthValidation(string name, string validatorType, bool Enabled, bool on_failure_halt) : base(name, validatorType, Enabled, on_failure_halt)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            bool retVal = false;
            var xpath = this.LocalAttributes
                        .Where(field => field.name == Constants.LengthValidation_CustomFields.OrderNumber)
                        .First<ValidationRuleEngine.Configuration.Attribute>().value;
            //base.Validate(obj, currXDocument, mandatoryFields);
            XPathDocument xPathDoc = new XPathDocument(this.currentXml.Root.CreateReader(/*ReaderOptions.OmitDuplicateNamespaces*/));
            var xpathNavigator = xPathDoc.CreateNavigator();
            var matchingNodes = xpathNavigator.Select(xpath);
            if (matchingNodes == null || matchingNodes.Count == 0)
            {
                Console.WriteLine("No matching element found for rule {0}", this.LocalAttributes.Where(field => field.name == Constants.LengthValidation_CustomFields.OrderNumber).First<ValidationRuleEngine.Configuration.Attribute>().name);
                //continue;
            }

            Console.WriteLine("{0} matching nodes found for XPath {1}.", matchingNodes.Count, xpath);
            var length = this.LocalAttributes
                            .Where(item => item.name == Constants.LengthValidation_CustomFields.Length)
                            .First<ValidationRuleEngine.Configuration.Attribute>().value;
            var message = this.LocalAttributes
                            .Where(item => item.name == Constants.LengthValidation_CustomFields.Message)
                            .First<ValidationRuleEngine.Configuration.Attribute>().value; ;
            while (matchingNodes.MoveNext())
            {
                var currentXElement = XElement.Parse(matchingNodes.Current.OuterXml);

                Console.WriteLine("Executing validations for following xml Node.");
                Console.WriteLine(currentXElement.ToString());

                IValidationContext context = ValidatorEngine.GetContext(this.currentXml, currentXElement);
                //IValidationContext context = (IValidationContext)obj;
                if (context.CurrentElement.Value.Length.Equals(Int32.Parse(length)))
                {
                    Console.WriteLine("value of the field {0} is correct length.", context.CurrentElement.Name.ToString());
                    retVal = true;
                }
                else
                {
                    retVal = false;
                    break;
                }
                Console.WriteLine(message.Replace("$Attribute", context.CurrentElement.Name.ToString()).Replace("$Value", context.CurrentElement.Value));
            }//
            
            return retVal;
        }        
    }
}
