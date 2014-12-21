using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimpleValidation.Rules;

namespace SimpleValidation.Builders
{
    public class DateRuleBuilder<TTarget> : ValidatorBuilder<TTarget>, IDateRuleBuilder<TTarget>
    {
        private readonly Expression<Func<TTarget, DateTime>> propertySelector;

        public DateRuleBuilder(IList<IRule<TTarget>> rules, Expression<Func<TTarget, DateTime>> propertySelector)
            : base(rules)
        {
            this.propertySelector = propertySelector;
        }

        public IDateRuleBuilder<TTarget> LessThanToday()
        {
            this.Add(propertySelector, new CompareRule<DateTime>(Comparisons.LessThan, DateTime.Now));

            return this;
        }

        public IDateRuleBuilder<TTarget> GreaterThanToday()
        {
            this.Add(propertySelector, new CompareRule<DateTime>(Comparisons.GreaterThan, DateTime.Now));

            return this;
        }

        public IDateRuleBuilder<TTarget> NotDefault()
        {
            this.Add(propertySelector, new CompareRule<DateTime>(Comparisons.Different, default(DateTime)));

            return this;
        }
    }
}
