using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SampleInstances
{
    [Serializable]
    [XmlRoot(ElementName = "validation")]
    public class AccelosLookupValidator : ValidationRuleEngine.Implementations.Validation
    {
        public override bool Validate(object obj, XDocument currXDocument, string DocumentType, string orderNumber, string orderDate)
        {
            base.Validate(obj, currXDocument, DocumentType, orderNumber, orderDate);
            Console.WriteLine("Stay Tuned Folks: AccelosLookupValidator To be implemented soon");
            return(true);
        }
    }
}
