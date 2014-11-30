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
            Assert.AreEqual(true, new ComparisonBasedRule<DateTime>(() => reference.Date, Comparisons.LessThan, comparison.AddDays(-1)).Execute().IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<DateTime>(() => reference.Date, Comparisons.LessThanOrEqual, comparison.AddDays(-1)).Execute().IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<DateTime>(() => reference.Date, Comparisons.LessThanOrEqual, comparison).Execute().IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<DateTime>(() => reference.Date, Comparisons.Equal, comparison).Execute().IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<DateTime>(() => reference.Date, Comparisons.GreaterThanOrEqual, comparison).Execute().IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<DateTime>(() => reference.Date, Comparisons.GreaterThanOrEqual, comparison.AddDays(1)).Execute().IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<DateTime>(() => reference.Date, Comparisons.GreaterThan, comparison.AddDays(1)).Execute().IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_null_values()
        {
            // arrange
            string comparison = null;
            string reference = null;

            // assert
            Assert.AreEqual(false, new ComparisonBasedRule<string>(() => reference, Comparisons.LessThan, comparison).Execute().IsSuccess);
            Assert.AreEqual(false, new ComparisonBasedRule<string>(() => comparison, Comparisons.LessThan, reference).Execute().IsSuccess);
        }
    }
}