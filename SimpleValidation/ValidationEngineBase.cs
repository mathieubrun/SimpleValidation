using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimpleValidation.Builders;

namespace SimpleValidation
{
    public abstract class ValidationEngineBase<T> : ValidatorBuilder<T>, IValidatorBuilder<T>
    {
        protected ValidationEngineBase() : base(new List<IRule<T>>())
        {
        }

        public IEnumerable<ValidationResult> Validate(T target)
        {
            return this.Rules.Select(x => x.Execute(target)).ToArray();
        }
    }
}
