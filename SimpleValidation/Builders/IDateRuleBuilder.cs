namespace SimpleValidation.Builders
{
    public interface IDateRuleBuilder<TTarget> : IRuleBuilderBase<TTarget, IDateRuleBuilder<TTarget>>
    {
        IDateRuleBuilder<TTarget> LessThanToday();

    }
}