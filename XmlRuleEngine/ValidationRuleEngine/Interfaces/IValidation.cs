using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ValidationRuleEngine.Interfaces
{
    public interface IValidation
    {
        string Name { get; set; }

        string validator_type { get; set; }

        bool enabled { get; set; }
        
        bool Validate(/*Object obj, XDocument currXDocument, List<Attribute> fieldArray*/);

        /// <summary>
        /// This method takes 2 attributes. 
        /// Firstly creates a local copy of globalAttributes and then populates its values.
        /// Secondly it populates localAttributeValues
        /// </summary>
        /// <param name="globalAttributes"></param>
        /// <param name="currXDocument"></param>
        void LoadGlobalAttributeValues(List<Attribute> globalAttributes, XDocument currXDocument);
    }
}
