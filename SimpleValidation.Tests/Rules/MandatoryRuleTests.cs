using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleValidation.Builders;
using SimpleValidation.Rules;

namespace SimpleValidation.Tests.Rules
{
    [TestClass]
    public class MandatoryRuleTests
    {
        [TestMethod]
        public void Execute_must_return_failure_if_property_is_default()
        {
            // arrange
            var obj = new Person();
            var sut = new MandatoryRule<string>(() => obj.FirstName);

            // act
            var result = sut.Execute();

            // assert
            Assert.AreEqual(false, result.IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_success_if_property_is_not_default()
        {
            // arrange
            var obj = new Person() { FirstName = "Test" };
            var sut = new MandatoryRule<string>(() => obj.FirstName);

            // act
            var result = sut.Execute();

            // assert
            Assert.AreEqual(true, result.IsSuccess);
        }
    }
}