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
        public void Execute_must_return_correct_ValidationResult()
        {
            // arrange
            var date = DateTime.Now;
            var obj = new Person() { DateOfBirth = date };

            // assert
            Assert.AreEqual(true, new ComparisonBasedRule<DateTime>(() => obj.DateOfBirth, Comparisons.LessThan, date.AddDays(-1)).Execute().IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<DateTime>(() => obj.DateOfBirth, Comparisons.LessThanOrEqual, date.AddDays(-1)).Execute().IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<DateTime>(() => obj.DateOfBirth, Comparisons.LessThanOrEqual, date).Execute().IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<DateTime>(() => obj.DateOfBirth, Comparisons.Equal, date).Execute().IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<DateTime>(() => obj.DateOfBirth, Comparisons.GreaterThanOrEqual, date).Execute().IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<DateTime>(() => obj.DateOfBirth, Comparisons.GreaterThanOrEqual, date.AddDays(1)).Execute().IsSuccess);
            Assert.AreEqual(true, new ComparisonBasedRule<DateTime>(() => obj.DateOfBirth, Comparisons.GreaterThan, date.AddDays(1)).Execute().IsSuccess);
        }
    }
}