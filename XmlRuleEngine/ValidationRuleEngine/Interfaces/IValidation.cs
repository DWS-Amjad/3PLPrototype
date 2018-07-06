namespace ValidationRuleEngine.Interfaces
{
    public interface IValidation
    {
        string Name { get; set; }
        bool Validate(IValidationContext context);
    }
}
