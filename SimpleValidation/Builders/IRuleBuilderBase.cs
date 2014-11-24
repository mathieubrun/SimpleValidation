namespace SimpleValidation.Builders
{
    public interface IRuleBuilderBase<TTarget, TValidatorBuilder> : IValidatorBuilder<TTarget> where TValidatorBuilder : IValidatorBuilder<TTarget>
    {
        TValidatorBuilder NotEmpty();
    }
}