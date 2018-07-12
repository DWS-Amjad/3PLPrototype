using System;

namespace ValidationRuleEngine.Interfaces
{
    public interface IValidation
    {
        string Name { get; set; }

        string validator_type { get; set; }

        bool enabled { get; set; }

        bool Validate(Object obj);
        //bool Validate(IValidationContext context);
    }
}
