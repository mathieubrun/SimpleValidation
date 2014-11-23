namespace SimpleValidation.Builders
{
    public interface IStringRuleBuilder<TTarget> : IRuleBuilderBase<TTarget, IStringRuleBuilder<TTarget>>
    {
        IStringRuleBuilder<TTarget> NotWhiteSpace();

        IStringRuleBuilder<TTarget> Email();
    }
}