using System;
using System.Xml.Serialization;
using ValidationRuleEngine.Interfaces;

namespace SampleInstances
{
    [Serializable]
    [XmlRoot(ElementName = "validation")]
    public class AccelosLookupValidator : IValidation
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("validator_type")]
        public string validator_type { get; set; }

        [XmlAttribute("enabled")]
        public bool enabled { get; set; }

        public bool Validate(object obj)
        {
            Console.WriteLine("Stay Tuned Folks: AccelosLookupValidator To be implemented soon");
            return(true);
        }
    }
}
