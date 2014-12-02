﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidation.Builders
{
    public class ValidatorBuilder<TTarget> : IValidatorBuilder<TTarget>
    {
        private readonly IList<ITargetedRule<TTarget>> rules;

        public ValidatorBuilder(IList<ITargetedRule<TTarget>> rules)
        {
            this.rules = rules;
        }

        public IDateRuleBuilder<TTarget> RuleFor(Expression<Func<TTarget, DateTime?>> propertySelector)
        {
            throw new NotImplementedException();
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

        public ICompositeRuleBuilder<TTarget, IDateRules> RulesFor(Expression<Func<TTarget, DateTime?>> propertySelector)
        {
            throw new NotImplementedException();
        }

        public ICompositeRuleBuilder<TTarget, IDateRules> RulesFor(Expression<Func<TTarget, DateTime>> propertySelector)
        {
            throw new NotImplementedException();
        }

        public ICompositeRuleBuilder<TTarget, IStringRules> RulesFor(Expression<Func<TTarget, string>> propertySelector)
        {
            throw new NotImplementedException();
        }

        public ICompositeRuleBuilder<TTarget, IDefaultRules> RulesFor<TProperty>(Expression<Func<TTarget, TProperty>> propertySelector)
        {
            throw new NotImplementedException();
        }

        protected void Add(ITargetedRule<TTarget> rule)
        {
            this.rules.Add(rule);
        }
    }
}