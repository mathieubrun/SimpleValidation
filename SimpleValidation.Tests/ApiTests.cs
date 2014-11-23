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
                    .NotEmpty()
                    .LessThanToday()
                .RuleFor(x => x.FirstName)
                    .NotEmpty()
                    .NotWhiteSpace()
                .RuleFor(x => x.LastName)
                    .NotWhiteSpace();
        }
    }
}