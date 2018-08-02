using System.Xml.Linq;
using ValidationRuleEngine.Interfaces;

namespace ValidationRuleEngine.Implementations
{
    public class ValidationContext : IValidationContext
    {
        public XDocument XmlDoc { get; private set; }
        public XElement ParentElement { get; private set; }
        public XElement CurrentElement { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="parentElement"></param>
        /// <param name="currentElement"></param>
        protected internal ValidationContext(XDocument xmlDoc, XElement parentElement, XElement currentElement)
        {
            this.CurrentElement = currentElement;
            this.ParentElement = parentElement;
            this.XmlDoc = xmlDoc;
        }
    }
}