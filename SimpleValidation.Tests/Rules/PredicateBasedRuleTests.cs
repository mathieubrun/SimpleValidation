using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleValidation.Builders;
using SimpleValidation.Rules;

namespace SimpleValidation.Tests.Rules
{
    [TestClass]
    public class PredicateBasedRuleTests
    {
        [TestMethod]
        public void Execute_must_return_correct_ValidationResult()
        {
            // arrange
            var reference1 = new TestObject() { String = "" };
            var reference2 = new TestObject() { String = " " };
            var reference3 = new TestObject() { String = null };

            var sut = new PredictateBasedRule<TestObject, string>(x => x.String, x => !string.IsNullOrWhiteSpace(x));

            // assert
            Assert.AreEqual(false, sut.Execute(reference1).IsSuccess);
            Assert.AreEqual(false, sut.Execute(reference2).IsSuccess);
            Assert.AreEqual(false, sut.Execute(reference3).IsSuccess);
        }
    }
}