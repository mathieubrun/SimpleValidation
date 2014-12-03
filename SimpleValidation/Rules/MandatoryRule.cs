using System;
using System.Linq.Expressions;

namespace SimpleValidation.Rules
{
    public class MandatoryRule<TTarget, TProperty> : ExpressionBasedRule<TTarget, TProperty>
    {
        public MandatoryRule(Expression<Func<TTarget, TProperty>> getProperty)
            : base(getProperty)
        {
        }

        public override ValidationResult Execute(TTarget target)
        {
            var result = GetValue(target);

            if (!object.Equals(default(TProperty), result))
            {
                return ValidationResult.Success();
            }

            return ValidationResult.Failure();
        }
    }
}