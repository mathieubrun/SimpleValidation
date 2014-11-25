using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidation.Builders
{
    public interface IDefaultRuleBuilder<TTarget> :
        IDefaultRules<IDefaultRuleBuilder<TTarget>>,
        IValidatorBuilder<TTarget>
    {
    }

    public interface IDefaultRules : IDefaultRules<IDefaultRules>
    {
    }

    public interface IDefaultRules<TReturn>
    {
        TReturn NotNull();
    }
}
