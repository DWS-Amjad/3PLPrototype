﻿using System.Collections.Generic;
using ValidationRuleEngine.Interfaces;

namespace ValidationRuleEngine.Implementations
{
    internal class Rule : IRule
    {
        public Rule(string name, string xpath, bool enabled)
        {
            Name = name;
            Xpath = xpath;
            Enabled = enabled; 
        }


        public string Name { get; private set; }

        public string Xpath { get; private set; }

        public bool Enabled { get; private set; }

        public IEnumerable<IValidation> Validations
        {
            get;
            set;
        }

        public IEnumerable<IAction> Actions
        {
            get;
            set;
        }
    }
}