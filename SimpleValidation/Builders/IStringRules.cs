namespace SimpleValidation.Builders
{
    public interface IStringRuleBuilder<TTarget> :
        IStringRules<IStringRuleBuilder<TTarget>>,
        IValidatorBuilder<TTarget>
    {
    }

    public interface IStringRules<TReturn> : IDefaultRules<TReturn>
    {
        TReturn Email();

        TReturn NotWhitespace();

        TReturn NotEmpty();
    }

    public interface IStringRules : IStringRules<IStringRules>
    {
    }
}