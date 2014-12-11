using System.Collections.Generic;
using SimpleValidation.Rules;

namespace SimpleValidation
{
    public interface IValidationEngine<T>
    {
        IEnumerable<ValidationResult> Validate(T target);
    }
}