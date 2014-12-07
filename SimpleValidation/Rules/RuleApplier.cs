using System;
using System.Linq.Expressions;

namespace SimpleValidation.Rules
{
    public class RuleApplier<TTarget, TProperty> : ExpressionBasedRule<TTarget, TProperty>
    {
        private readonly IRule<TProperty> rule;

        public RuleApplier(Expression<Func<TTarget, TProperty>> propertySelector, IRule<TProperty> rule)
            : base(propertySelector)
        {
            this.rule = rule;
        }

        public override ValidationResult Execute(TTarget target)
        {
            var value = GetValue(target);

            return this.rule.Execute(value);
        }
    }
}