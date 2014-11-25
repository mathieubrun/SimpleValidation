using System;
using System.Linq.Expressions;

namespace SimpleValidation.Rules
{
    public abstract class ExpressionBasedRule<TProperty> : IRule
    {
        private readonly Func<TProperty> getValue;

        public ExpressionBasedRule(Expression<Func<TProperty>> getProperty)
        {
            this.getValue = getProperty.Compile();
        }

        public abstract ValidationResult Execute();

        protected TProperty GetValue()
        {
            return getValue();
        }
    }
}