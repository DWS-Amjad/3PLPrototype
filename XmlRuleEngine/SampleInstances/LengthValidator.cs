using System;
using System.Xml.Serialization;
using ValidationRuleEngine.Interfaces;

namespace SampleInstances
{
    [Serializable]
    [XmlRoot(ElementName = "validation")]
    public class LengthValidator : IValidation
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        #region Custome Properties
        
        [XmlElement("length")]
        public string Length { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }

        #endregion

        public bool Validate(IValidationContext context)
        {
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
