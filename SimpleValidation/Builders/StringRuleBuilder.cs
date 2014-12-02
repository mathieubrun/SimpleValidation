using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimpleValidation.Rules;

namespace SimpleValidation.Builders
{
    public class StringRuleBuilder<TTarget> : ValidatorBuilder<TTarget>,
        IStringRuleBuilder<TTarget>
    {
        private readonly Expression<Func<TTarget, string>> propertySelector;

        public StringRuleBuilder(IList<ITargetedRule<TTarget>> rules, Expression<Func<TTarget, string>> propertySelector)
            : base(rules)
        {
            this.propertySelector = propertySelector;
        }

        public IStringRuleBuilder<TTarget> Email()
        {
            throw new NotImplementedException();
        }

        public IStringRuleBuilder<TTarget> NotWhitespace()
        {
            this.Add(new ComparisonBasedRule<TTarget, string>(propertySelector, Comparisons.Different, ""));

            return this;
        }

        public IStringRuleBuilder<TTarget> NotEmpty()
        {
            throw new NotImplementedException();
        }

        public IStringRuleBuilder<TTarget> NotDefault()
        {
            this.Add(new PredictateBasedRule<TTarget, string>(propertySelector, x => x != null));

            return this;
        }
    }
}
