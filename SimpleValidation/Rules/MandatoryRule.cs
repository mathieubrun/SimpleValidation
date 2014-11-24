using System;
using System.Linq.Expressions;

namespace SimpleValidation.Rules
{
    public class MandatoryRule<TProperty> : IRule
    {
        private readonly Func<TProperty> getValue;

        public MandatoryRule(Expression<Func<TProperty>> getProperty)
        {
            this.getValue = getProperty.Compile();
        }

        public ValidationResult Execute()
        {
            var result = getValue();

            if (!object.Equals(default(TProperty), result))
            {
                return ValidationResult.Success();
            }

            return ValidationResult.Failure();
        }
    }
}