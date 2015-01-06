using System.Collections.Generic;
using SimpleValidation.Rules;

namespace SimpleValidation
{
    /// <summary>
    /// Validation engine interface
    /// </summary>
    /// <typeparam name="TTarget">Type to be validated</typeparam>
    public interface IValidationEngine<TTarget>
    {
        /// <summary>
        /// Executes a set of rules
        /// </summary>
        /// <param name="target">Validation target</param>
        /// <returns>Enumeration of Validation results</returns>
        IEnumerable<ValidationResult> Validate(TTarget target);
    }
}