using System;

namespace SimpleValidation.Tests
{
    public class TestValidationEngine : ValidationEngineBase<TestObject>
    {
        public TestValidationEngine()
        {
            RuleFor(x => x.String)
                .NotDefault()
                .NotWhitespace();

            RuleFor(x => x.Date)
                .NotDefault()
                .LessThanToday();

            RuleFor(x => x.Parent)
                .NotDefault()
                .RuleFor(x => x.Parent.Date)
                    .NotDefault()
                    .GreaterThanToday();
        }
    }
}