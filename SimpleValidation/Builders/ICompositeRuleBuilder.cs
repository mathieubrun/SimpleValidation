using System;
using System.Linq.Expressions;

namespace SimpleValidation.Builders
{
    public interface ICompositeRuleBuilder<TTarget, TRules> : IValidatorBuilder<TTarget>
    {
        ICompositeSuccessRuleBuilder<TTarget, TRules> Rules(params Expression<Action<TRules>>[] rules);
    }

    public interface ICompositeSuccessRuleBuilder<TTarget, TRules> : ICompositeRuleBuilder<TTarget, TRules>
    {
        ICompositeSuccessRuleBuilder<TTarget, TRules> Then(params Expression<Action<TRules>>[] rules);
    }
}