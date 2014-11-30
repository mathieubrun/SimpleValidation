using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleValidation.Builders;
using SimpleValidation.Rules;

namespace SimpleValidation.Tests.Rules
{
    [TestClass]
    public class ComparisonBasedRuleTests
    {
        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_DateTime()
        {
            // arrange
            var comparison = DateTime.Now;
            var reference = new TestObject() { Date = comparison };

            // assert
            Assert.AreEqual(true, new ComparisonBasedRule<TestObject, DateTime>(x => x.Date, Comparisons.LessThan, comparison.AddDays(-1)).Execute(reference).IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<TestObject, DateTime>(x => x.Date, Comparisons.LessThanOrEqual, comparison.AddDays(-1)).Execute(reference).IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<TestObject, DateTime>(x => x.Date, Comparisons.LessThanOrEqual, comparison).Execute(reference).IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<TestObject, DateTime>(x => x.Date, Comparisons.Equal, comparison).Execute(reference).IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<TestObject, DateTime>(x => x.Date, Comparisons.GreaterThanOrEqual, comparison).Execute(reference).IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<TestObject, DateTime>(x => x.Date, Comparisons.GreaterThanOrEqual, comparison.AddDays(1)).Execute(reference).IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<TestObject, DateTime>(x => x.Date, Comparisons.GreaterThan, comparison.AddDays(1)).Execute(reference).IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_null_values()
        {
            // arrange
            var reference = new TestObject() { String = null };
            string comparison = null;

            // assert
            Assert.AreEqual(false, new ComparisonBasedRule<TestObject, string>(x => x.String, Comparisons.LessThan, comparison).Execute(reference).IsSuccess);
        }
    }
}