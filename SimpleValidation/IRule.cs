namespace SimpleValidation
{
    public interface IRule<TProp>
    {
        ValidationResult Execute(TProp target);
    }
}