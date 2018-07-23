using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using ValidationRuleEngine.Interfaces;

namespace Customizations
{
    [Serializable]
    [XmlRoot(ElementName = "validation")]
    public class LengthValidator : ValidationRuleEngine.Implementations.Validation
    {
        #region Custom Properties

            [XmlElement("length")]
            public string Length { get; set; }

            [XmlElement("message")]
            public string Message { get; set; }
        
        #endregion

        public override bool Validate(Object obj, XDocument currXDocument, string DocumentType, string orderNumber, string orderDate)
        {
            base.Validate(obj, currXDocument, DocumentType, orderNumber, orderDate);
            IValidationContext context = (IValidationContext)obj;
            if (context.CurrentElement.Value.Length.Equals(Int32.Parse(Length)))
            {
                Console.WriteLine("value of the field {0} is correct length.", context.CurrentElement.Name.ToString());
                return true;
            }
            Console.WriteLine(Message.Replace("$Field", context.CurrentElement.Name.ToString()).Replace("$Value", context.CurrentElement.Value));
            return false;
        }        
    }
}
