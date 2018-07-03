namespace ValidationRuleEngine.Rules
{
    public interface IAction
    {
        string Name { get; set; }
        bool Execute(IValidationContext context);
    }
}
