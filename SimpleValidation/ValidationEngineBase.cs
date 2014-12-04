using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimpleValidation.Builders;

namespace SimpleValidation
{
    public abstract class ValidationEngineBase<T> : IValidatorBuilder<T>
    {
        private readonly IList<ITargetedRule<T>> rules = new List<ITargetedRule<T>>();

        protected ValidationEngineBase()
        {
        }

        public IEnumerable<ValidationResult> Validate(T target)
        {
            return this.rules.Select(x => x.Execute(target)).ToArray();
        }

        public IDateRuleBuilder<T> RuleFor(Expression<Func<T, DateTime?>> propertySelector)
        {
            throw new NotImplementedException();
        }

        public IDateRuleBuilder<T> RuleFor(Expression<Func<T, DateTime>> propertySelector)
        {
            return new DateRuleBuilder<T>(rules, propertySelector);
        }

        public IStringRuleBuilder<T> RuleFor(Expression<Func<T, string>> propertySelector)
        {
            return new StringRuleBuilder<T>(rules, propertySelector);
        }

        public IDefaultRuleBuilder<T> RuleFor<TProperty>(Expression<Func<T, TProperty>> propertySelector)
        {
            return new DefaultRuleBuilder<T, TProperty>(rules, propertySelector);
        }

        public ICompositeRuleBuilder<T, IDateRules> RulesFor(Expression<Func<T, DateTime?>> propertySelector)
        {
            throw new NotImplementedException();
        }

        public ICompositeRuleBuilder<T, IDateRules> RulesFor(Expression<Func<T, DateTime>> propertySelector)
        {
            throw new NotImplementedException();
        }

        public ICompositeRuleBuilder<T, IStringRules> RulesFor(Expression<Func<T, string>> propertySelector)
        {
            throw new NotImplementedException();
        }

        public ICompositeRuleBuilder<T, IDefaultRules> RulesFor<TProperty>(Expression<Func<T, TProperty>> propertySelector)
        {
            throw new NotImplementedException();
        }
    }
}
