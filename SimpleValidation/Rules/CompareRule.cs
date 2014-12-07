using System;
using System.Linq.Expressions;

namespace SimpleValidation.Rules
{
    public class CompareRule<TProperty> : IRule<TProperty> where TProperty : IComparable, IComparable<TProperty>
    {
        private readonly Comparisons comparison;
        private readonly TProperty reference;

        public CompareRule(Comparisons comparison, TProperty reference)
        {
            this.comparison = comparison;
            this.reference = reference;
        }

        public ValidationResult Execute(TProperty result)
        {
            if (reference == null)
            {
                return GetResult(false);
            }

            var comp = reference.CompareTo(result);

            switch (comparison)
            {
                case Comparisons.LessThan:
                    return GetResult(comp > 0);
                case Comparisons.LessThanOrEqual:
                    return GetResult(comp == 0 || comp > 0);
                case Comparisons.Equal:
                    return GetResult(comp == 0);
                case Comparisons.Different:
                    return GetResult(comp != 0);
                case Comparisons.GreaterThanOrEqual:
                    return GetResult(comp == 0 || comp < 0);
                case Comparisons.GreaterThan:
                    return GetResult(comp < 0);
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