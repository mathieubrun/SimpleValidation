namespace SimpleValidation
{
    /// <summary>
    /// Validation rule interface
    /// </summary>
    /// <typeparam name="TTarget">Type to validate</typeparam>
    public interface IRule<TTarget>
    {
        /// <summary>
        /// Executes rules agains target
        /// </summary>
        /// <param name="target">Object to be validated</param>
        /// <returns>Validation result</returns>
        ValidationResult Execute(TTarget target);
    }
}