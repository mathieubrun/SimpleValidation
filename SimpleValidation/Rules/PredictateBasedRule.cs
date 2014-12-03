using System;
using System.Linq.Expressions;

namespace SimpleValidation.Rules
{
    public class PredictateBasedRule<TTarget, TProperty> : ExpressionBasedRule<TTarget, TProperty> where TProperty : IComparable, IComparable<TProperty>
    {
        private readonly Predicate<TProperty> predicate;

        public PredictateBasedRule(Expression<Func<TTarget, TProperty>> getProperty, Predicate<TProperty> predicate)
            : base(getProperty)
        {
            this.predicate = predicate;
        }

        public override ValidationResult Execute(TTarget target)
        {
            var result = GetValue(target);

            if (predicate(result))
            {
                return ValidationResult.Success();
            }

            return ValidationResult.Failure();
        }
    }
}