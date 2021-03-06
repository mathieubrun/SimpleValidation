﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimpleValidation.Rules;

namespace SimpleValidation.Builders
{
    public class DefaultRuleBuilder<TTarget, TProperty> : ValidatorBuilder<TTarget>,
        IDefaultRuleBuilder<TTarget>
    {
        private readonly Expression<Func<TTarget, TProperty>> propertySelector;

        public DefaultRuleBuilder(IList<IRule<TTarget>> rules, Expression<Func<TTarget, TProperty>> propertySelector)
            : base(rules)
        {
            this.propertySelector = propertySelector;
        }

        public IDefaultRuleBuilder<TTarget> NotDefault()
        {
            this.Add(propertySelector, new MandatoryRule<TProperty>());

            return this;
        }
    }
}
