using System.Xml.Linq;
using ValidationRuleEngine.Interfaces;

namespace ValidationRuleEngine.Implementations
{
    public class ValidationContext : IValidationContext
    {
        public XDocument XmlDoc { get; private set; }
        public XElement ParentElement { get; private set; }
        public XElement CurrentElement { get; private set; }

        protected internal ValidationContext(XDocument xmlDoc, XElement parentElement, XElement currentElement)
        {
            this.CurrentElement = currentElement;
            this.ParentElement = parentElement;
            this.XmlDoc = xmlDoc;
        }
    }
}