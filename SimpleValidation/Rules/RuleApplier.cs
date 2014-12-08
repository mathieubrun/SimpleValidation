using System;
using System.Linq.Expressions;

namespace SimpleValidation.Rules
{
    public class RuleApplier<TTarget, TProperty> : IRule<TTarget>
    {
        private readonly IRule<TProperty> rule;
        private readonly Func<TTarget, TProperty> selector;

        public RuleApplier(Expression<Func<TTarget, TProperty>> propertySelector, IRule<TProperty> rule)
        {
            this.selector = propertySelector.Compile();
            this.rule = rule;
        }

        public ValidationResult Execute(TTarget target)
        {
            var value = GetValue(target);

            return this.rule.Execute(value);
        }

        protected TProperty GetValue(TTarget target)
        {
            return selector(target);
        }
    }
}