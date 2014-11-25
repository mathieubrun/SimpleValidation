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
            var sut = Mock.Of<IValidatorBuilder<Person>>();

            // act
            var rule = sut
                .RuleFor(x => x.DateOfBirth)
                    .NotNull()
                    .LessThanToday()
                .RuleFor(x => x.Parent)
                    .NotNull()
                .RulesFor(x => x.FirstName)
                    .Rules(x => x.NotNull())
                        .Then(x => x.NotWhitespace());
        }
    }
}