using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
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

        #region Local Attributes
        [XmlArrayAttribute("attributes")]
        [XmlArrayItemAttribute("attribute")]
        public List<ValidationRuleEngine.Configuration.Attribute> LocalAttributes;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Action()
        {
            this.LocalAttributes = new List<ValidationRuleEngine.Configuration.Attribute>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NameArg"></param>
        /// <param name="executeOnArg"></param>
        /// <param name="enabledArg"></param>
        public Action(string NameArg, string executeOnArg, bool enabledArg)
        {
            this.Name = NameArg;
            this.executeOn = executeOnArg;
            this.enabled = enabledArg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xpathNavigator"></param>
        public void LoadLocalAttributesValues(XPathNavigator xpathNavigator)
        {
            XPathNodeIterator xPathIterator;
            foreach (var item in this.LocalAttributes)
            {
                if (String.IsNullOrEmpty(item.value))
                {
                    if (!String.IsNullOrEmpty(item.path))
                    {
                        xPathIterator = xpathNavigator.Select(item.path);
                        if (xPathIterator.Count > 0)
                        {
                            while (xPathIterator.MoveNext())
                            {
                                this.LocalAttributes
                                    .Where(field => field.name == item.name)
                                    .First<ValidationRuleEngine.Configuration.Attribute>().value = xPathIterator.Current.Value.Trim();
                            }
                        }
                        else
                        {
                            Console.WriteLine(String.Format("\"{0}\" path found in XML Document.", item.path));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual bool Execute(Object obj)
        {
            return true;
        }
    }
}
