namespace ValidationRuleEngine.Rules
{
    public interface IValidation
    {
        string Name { get; set; }
        bool Validate(IValidationContext context);
    }
}
