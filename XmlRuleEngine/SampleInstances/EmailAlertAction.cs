using System;
using System.Xml.Serialization;
using ValidationRuleEngine.Interfaces;

namespace SampleInstances
{
    [Serializable]
    [XmlRoot(ElementName = "action")]
    public class EmailAlertAction : IAction
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        #region Custome Properties
        [XmlElement("to")]
        public string To { get; set; }
        
        [XmlElement("from")]
        public string From { get; set; }

        [XmlElement("subject")]
        public string Subject { get; set; }

        [XmlElement("successMessage")]
        public string SuccessMessage { get; set; }

        [XmlElement("failureMessage")]
        public string FailureMessage { get; set; }

        #endregion

        public bool Execute(IValidationContext context)
        {
            Console.WriteLine("Name of actionMethod : {0}", Name);
            return true;
        }
    }
}