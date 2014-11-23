using System;
using System.Linq.Expressions;

namespace SimpleValidation.Builders
{
    public interface IValidatorBuilder<TTarget>
    {
        IStringRuleBuilder<TTarget> RuleFor(Expression<Func<TTarget, string>> propertySelector);

        IDateRuleBuilder<TTarget> RuleFor(Expression<Func<TTarget, DateTime>> propertySelector);
    }
}