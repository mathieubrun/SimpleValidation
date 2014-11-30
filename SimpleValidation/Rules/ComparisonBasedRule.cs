using System;
using System.Linq.Expressions;

namespace SimpleValidation.Rules
{
    public class ComparisonBasedRule<TTarget, TProperty> : ExpressionBasedRule<TTarget, TProperty> where TProperty : IComparable, IComparable<TProperty>
    {
        private readonly Comparisons comparison;
        private readonly TProperty reference;

        public ComparisonBasedRule(Expression<Func<TTarget, TProperty>> getProperty, Comparisons comparison, TProperty reference)
            : base(getProperty)
        {
            this.comparison = comparison;
            this.reference = reference;
        }

        public override ValidationResult Execute(TTarget target)
        {
            var result = GetValue(target);

            if (reference == null)
            {
                return GetResult(false);
            }

            var comp = reference.CompareTo(result);

            switch (comparison)
            {
                case Comparisons.LessThan:
                    return GetResult(comp < 0);
                case Comparisons.LessThanOrEqual:
                    return GetResult(comp == 0 || comp < 0);
                case Comparisons.Equal:
                    return GetResult(comp == 0);
                case Comparisons.Different:
                    return GetResult(comp != 0);
                case Comparisons.GreaterThanOrEqual:
                    return GetResult(comp == 0 || comp > 0);
                case Comparisons.GreaterThan:
                    return GetResult(comp > 0);
                default:
                    return GetResult(false);
            }
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