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

        [XmlAttribute("validator_type")]
        public string validator_type { get; set; }

        [XmlAttribute("enabled")]
        public bool enabled { get; set; }

        #region Custom Properties

        [XmlElement("length")]
        public string Length { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }
        //string IValidation.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion

        public bool Validate(Object obj)
        {
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
