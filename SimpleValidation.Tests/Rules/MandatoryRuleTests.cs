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
            var obj = new TestObject();
            var sut = new MandatoryRule<TestObject, string>(x => x.String);

            // act
            var result = sut.Execute(obj);

            // assert
            Assert.AreEqual(false, result.IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_success_if_property_is_not_default()
        {
            // arrange
            var obj = new TestObject() { String = "Test" };
            var sut = new MandatoryRule<TestObject, string>(x => x.String);

            // act
            var result = sut.Execute(obj);

            // assert
            Assert.AreEqual(true, result.IsSuccess);
        }
    }
}