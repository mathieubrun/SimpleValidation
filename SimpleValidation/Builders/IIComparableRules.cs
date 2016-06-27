using System;

namespace SimpleValidation.Builders
{
    public interface IIComparableRuleBuilder<TTarget, TProp> : IIComparableRules<IIComparableRuleBuilder<TTarget, TProp>, TProp>, IValidatorBuilder<TTarget>
        where TProp : struct, IComparable<TProp>
    {
    }

    public interface IIComparableRules<TReturn, TProp> : IDefaultRules<TReturn>
    {
        TReturn LessThan(IComparable<TProp> value);

        TReturn GreaterThan(IComparable<TProp> value);

        TReturn Between(IComparable<TProp> min, IComparable<TProp> max);
    }
}