using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimpleValidation.Rules;

namespace SimpleValidation.Builders
{
    public class ValidatorBuilder<TTarget> : IValidatorBuilder<TTarget>
    {
        private readonly IList<IRule<TTarget>> rules;

        public ValidatorBuilder(IList<IRule<TTarget>> rules)
        {
            this.rules = rules;
        }

        protected IEnumerable<IRule<TTarget>> Rules
        {
            get
            {
                return rules;
            }
        }

        public IDateRuleBuilder<TTarget> RuleFor(Expression<Func<TTarget, DateTime?>> propertySelector)
        {
            return new DateRuleBuilder<TTarget>(rules, propertySelector);
        }

        public IDateRuleBuilder<TTarget> RuleFor(Expression<Func<TTarget, DateTime>> propertySelector)
        {
            return new DateRuleBuilder<TTarget>(rules, propertySelector);
        }

        public IStringRuleBuilder<TTarget> RuleFor(Expression<Func<TTarget, string>> propertySelector)
        {
            return new StringRuleBuilder<TTarget>(rules, propertySelector);
        }

        public IDefaultRuleBuilder<TTarget> RuleFor<TProperty>(Expression<Func<TTarget, TProperty>> propertySelector)
        {
            return new DefaultRuleBuilder<TTarget, TProperty>(rules, propertySelector);
        }

        protected void Add<TProperty>(Expression<Func<TTarget, TProperty>> propertySelector, IRule<TProperty> rule)
        {
            this.rules.Add(new RuleApplier<TTarget, TProperty>(propertySelector, rule));
        }
    }
}
