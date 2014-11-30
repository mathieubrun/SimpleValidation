using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleValidation.Builders;

namespace SimpleValidation.Tests
{
    [TestClass]
    public class ApiTests
    {
        [Ignore]
        public void This_must_compile()
        {
            // arrange
            var sut = Mock.Of<IValidatorBuilder<TestObject>>();

            // act
            var rule = sut
                .RuleFor(x => x.Date)
                    .NotDefault()
                    .LessThanToday()
                .RuleFor(x => x.NullDate)
                    .NotDefault()
                    .LessThanToday()
                .RuleFor(x => x.Parent)
                    .NotDefault()
                .RulesFor(x => x.String)
                    .Rules(x => x.NotDefault())
                        .Then(x => x.NotWhitespace());
        }
    }
}