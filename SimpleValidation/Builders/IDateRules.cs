namespace SimpleValidation.Builders
{
    public interface IDateRuleBuilder<TTarget> :
        IDateRules<IDateRuleBuilder<TTarget>>,
        IValidatorBuilder<TTarget>
    {
    }

    public interface IDateRules<TReturn> : IDefaultRules<TReturn>
    {
        TReturn LessThanToday();

        TReturn GreaterThanToday();
    }

    public interface IDateRules : IDateRules<IDateRules>
    {
    }
}