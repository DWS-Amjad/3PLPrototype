using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Customizations
{
    [Serializable]
    [XmlRoot(ElementName = "validation")]
    public class AccelosLookupValidation : ValidationRuleEngine.Implementations.Validation
    {
        public override bool Validate(/*object obj*/)
        {
            Console.WriteLine("Stay Tuned Folks: AccelosLookupValidation To be implemented soon");
            return(true);
        }
    }
}
