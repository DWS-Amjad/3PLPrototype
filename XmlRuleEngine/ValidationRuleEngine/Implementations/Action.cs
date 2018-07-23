using System;
using System.Xml.Serialization;
using ValidationRuleEngine.Interfaces;

namespace ValidationRuleEngine.Implementations
{
    public class Action : IAction
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("executeOn")]
        public string executeOn { get; set; }

        [XmlAttribute("enabled")]
        public bool enabled { get; set; }

        public Action()
        {
        }

        public Action(string NameArg, string executeOnArg, bool enabledArg)
        {
            this.Name = NameArg;
            this.executeOn = executeOnArg;
            this.enabled = enabledArg;
        }

        public virtual bool Execute(Object obj)
        {
            return true;
        }
    }
}
