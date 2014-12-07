using System;
using System.Linq.Expressions;

namespace SimpleValidation.Rules
{
    public class PredictateRule<TProperty> : IRule<TProperty> where TProperty : IComparable, IComparable<TProperty>
    {
        private readonly Predicate<TProperty> predicate;

        public PredictateRule(Predicate<TProperty> predicate)
        {
            this.predicate = predicate;
        }

        public ValidationResult Execute(TProperty target)
        {
            if (predicate(target))
            {
                return ValidationResult.Success();
            }

            return ValidationResult.Failure();
        }
    }
}