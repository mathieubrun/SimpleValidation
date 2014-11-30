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

            return GetResult(predicate(result));
        }

        private ValidationResult GetResult(bool success, string message = null)
        {
            if (success)
            {
                return ValidationResult.Success(message);
            }

            return ValidationResult.Failure(message);
        }
    }
}