using System.Collections.Generic;

namespace ValidationRuleEngine.Interfaces
{
    public interface IRule
    {
        string Name { get; }

        string Xpath { get; }

        bool Enabled { get; }

        IEnumerable<IValidation> Validations { get; set; }

        IEnumerable<IAction> Actions { get; set; }
    }
}
