using System;
using System.Linq.Expressions;

namespace SimpleValidation.Rules
{
    public enum Comparisons
    {
        LessThan,

        LessThanOrEqual,

        Equal,

        Different,
        
        GreaterThanOrEqual,
        
        GreaterThan
    }
}