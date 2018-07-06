using System.Xml.Linq;

namespace ValidationRuleEngine.Interfaces
{
    public interface IValidationContext
    {
        XDocument XmlDoc { get; }

        XElement ParentElement { get; }

        XElement CurrentElement { get; }
    }
}
