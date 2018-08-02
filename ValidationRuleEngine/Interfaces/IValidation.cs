using System.Collections.Generic;
using System.Xml.Linq;
using ValidationRuleEngine.Implementations;

namespace ValidationRuleEngine.Interfaces
{
    public interface IValidation
    {
        string Name { get; set; }

        string validator_type { get; set; }

        bool enabled { get; set; }

        bool onFailureHalt { get; set; }

        IEnumerable<IAction> Actions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool Validate();

        /// <summary>
        /// This method takes 2 attributes. 
        /// Firstly creates a local copy of globalAttributes and then populates its values.
        /// Secondly it populates localAttributeValues
        /// </summary>
        /// <param name="globalAttributes"></param>
        /// <param name="currXDocument"></param>
        void LoadGlobalAttributeValues(List<ValidationRuleEngine.Configuration.Attribute> globalAttributes, XDocument currXDocument);
    }
}
