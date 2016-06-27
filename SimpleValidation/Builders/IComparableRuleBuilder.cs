using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimpleValidation.Rules;

namespace SimpleValidation.Builders
{
    public class IComparableRuleBuilder<TTarget, TProp> : ValidatorBuilder<TTarget>, IIComparableRuleBuilder<TTarget, TProp>
        where TProp : struct, IComparable<TProp>
    {
        private readonly Expression<Func<TTarget, TProp>> propertySelector;

        public IComparableRuleBuilder(IList<IRule<TTarget>> rules, Expression<Func<TTarget, TProp>> propertySelector)
            : base(rules)
        {
            this.propertySelector = propertySelector;
        }

        public IIComparableRuleBuilder<TTarget, TProp> LessThan(IComparable<TProp> value)
        {
            this.Add(propertySelector, new CompareRule<TProp>(Comparisons.LessThan, value));

            return this;
        }

        public IIComparableRuleBuilder<TTarget, TProp> GreaterThan(IComparable<TProp> value)
        {
            this.Add(propertySelector, new CompareRule<TProp>(Comparisons.GreaterThan, value));

            return this;
        }

        public IIComparableRuleBuilder<TTarget, TProp> Between(IComparable<TProp> min, IComparable<TProp> max)
        {
            this.Add(propertySelector, new CompareRule<TProp>(Comparisons.GreaterThan, min));
            this.Add(propertySelector, new CompareRule<TProp>(Comparisons.LessThan, max));

            return this;
        }

        public IIComparableRuleBuilder<TTarget, TProp> NotDefault()
        {
            this.Add(propertySelector, new CompareRule<TProp>(Comparisons.Different, default(TProp)));

            return this;
        }
    }
}
