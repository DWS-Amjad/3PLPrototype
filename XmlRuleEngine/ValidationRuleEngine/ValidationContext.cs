using System.Xml.Linq;

namespace ValidationRuleEngine
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