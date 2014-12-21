namespace SimpleValidation.Builders
{
    public interface IStringRuleBuilder<TTarget> : IStringRules<IStringRuleBuilder<TTarget>>, IValidatorBuilder<TTarget>
    {
    }

    public interface IStringRules<TReturn> : IDefaultRules<TReturn>
    {
        TReturn Regex(string regex);

        TReturn Email();

        TReturn NotWhitespace();

        TReturn NotEmpty();
    }
}