using System.Collections.Generic;
using System.Xml.Linq;
using ValidationRuleEngine.Rules;

namespace ValidationRuleEngine
{
    public interface IEngine
    {
        //XDocument ConfigXml { get; }

        //IEnumerable<IRule> Rules { get; }

        void Configure();
        void Start();
        //void Start(XDocument xmlDocument);

        void Stop();
    }
}
