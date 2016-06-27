using System;
using System.Linq.Expressions;
using SimpleValidation.Builders;

namespace SimpleValidation.Builders
{
    public interface IValidatorBuilder<TTarget>
    {
        IIComparableRuleBuilder<TTarget, int> RuleFor(Expression<Func<TTarget, int>> propertySelector);

        IDateRuleBuilder<TTarget> RuleFor(Expression<Func<TTarget, DateTime?>> propertySelector);

        IDateRuleBuilder<TTarget> RuleFor(Expression<Func<TTarget, DateTime>> propertySelector);

        IStringRuleBuilder<TTarget> RuleFor(Expression<Func<TTarget, string>> propertySelector);

        IDefaultRuleBuilder<TTarget> RuleFor<TProperty>(Expression<Func<TTarget, TProperty>> propertySelector);
    }
}