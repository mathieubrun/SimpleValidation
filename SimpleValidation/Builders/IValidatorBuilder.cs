using System;
using System.Linq.Expressions;
using SimpleValidation.Builders;

namespace SimpleValidation.Builders
{
    public interface IValidatorBuilder<TTarget>
    {
        IDateRuleBuilder<TTarget> RuleFor(Expression<Func<TTarget, DateTime>> propertySelector);

        IStringRuleBuilder<TTarget> RuleFor(Expression<Func<TTarget, string>> propertySelector);

        IDefaultRuleBuilder<TTarget> RuleFor<TProperty>(Expression<Func<TTarget, TProperty>> propertySelector);

        ICompositeRuleBuilder<TTarget, IDateRules> RulesFor(Expression<Func<TTarget, DateTime>> propertySelector);

        ICompositeRuleBuilder<TTarget, IStringRules> RulesFor(Expression<Func<TTarget, string>> propertySelector);

        ICompositeRuleBuilder<TTarget, IDefaultRules> RulesFor<TProperty>(Expression<Func<TTarget, TProperty>> propertySelector);
    }
}