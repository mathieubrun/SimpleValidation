﻿using System;
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
            // from http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx/
            return Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");
        }

        public IStringRuleBuilder<TTarget> Regex(string pattern)
        {
            var regexp = new System.Text.RegularExpressions.Regex(pattern);

            this.Add(new PredictateBasedRule<TTarget, string>(propertySelector, x => regexp.IsMatch(x)));

            return this;
        }

        public IStringRuleBuilder<TTarget> NotWhitespace()
        {
            this.Add(new PredictateBasedRule<TTarget, string>(propertySelector, x => !string.IsNullOrWhiteSpace(x)));

            return this;
        }

        public IStringRuleBuilder<TTarget> NotEmpty()
        {
            this.Add(new ComparisonBasedRule<TTarget, string>(propertySelector, Comparisons.Different, ""));

            return this;
        }

        public IStringRuleBuilder<TTarget> NotDefault()
        {
            this.Add(new PredictateBasedRule<TTarget, string>(propertySelector, x => x != null));

            return this;
        }
    }
}
