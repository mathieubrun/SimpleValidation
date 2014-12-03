namespace SimpleValidation
{
    public interface ITargetedRule<TTarget>
    {
        ValidationResult Execute(TTarget target);
    }

    public interface IRule
    {
        ValidationResult Execute();
    }
}