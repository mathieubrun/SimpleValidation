using System;
using System.Linq.Expressions;

namespace SimpleValidation.Rules
{
    public abstract class ExpressionBasedRule<TTarget, TProperty> : IRule<TTarget>
    {
        private readonly Func<TTarget, TProperty> selector;

        public ExpressionBasedRule(Expression<Func<TTarget, TProperty>> propertySelector)
        {
            this.selector = propertySelector.Compile();
        }

        public abstract ValidationResult Execute(TTarget target);

        protected TProperty GetValue(TTarget target)
        {
            return selector(target);
        }
    }
}