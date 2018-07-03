using System.Xml.Linq;

namespace ValidationRuleEngine
{
    public interface IValidationContext
    {
        XDocument XmlDoc { get; }

        XElement ParentElement { get; }

        XElement CurrentElement { get; }
    }
}
