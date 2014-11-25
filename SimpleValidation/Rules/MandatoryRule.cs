using System;
using System.Linq.Expressions;

namespace SimpleValidation.Rules
{
    public class MandatoryRule<TProperty> : ExpressionBasedRule<TProperty>
    {
        public MandatoryRule(Expression<Func<TProperty>> getProperty)
            : base(getProperty)
        {
        }

        public override ValidationResult Execute()
        {
            var result = GetValue();

            if (!object.Equals(default(TProperty), result))
            {
                return ValidationResult.Success();
            }

            return ValidationResult.Failure();
        }
    }
}