using System;
using System.Linq.Expressions;

namespace SimpleValidation.Rules
{
    public class MandatoryRule<TProperty> : IRule<TProperty>
    {
        public ValidationResult Execute(TProperty value)
        {
            if (!object.Equals(default(TProperty), value))
            {
                return ValidationResult.Success();
            }

            return ValidationResult.Failure();
        }
    }
}