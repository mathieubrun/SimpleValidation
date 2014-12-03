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
        public void Execute_must_return_correct_ValidationResult_for_DateTime_LessThan()
        {
            // arrange
            var tomorrow = DateTime.Now.AddDays(1);
            var now = new TestObject() { Date = DateTime.Now };

            var sut = new ComparisonBasedRule<TestObject, DateTime>(x => x.Date, Comparisons.LessThan, tomorrow);

            // assert
            Assert.AreEqual(true, sut.Execute(now).IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_DateTime_LessThanOrEqual()
        {
            // arrange
            var tomorrow = DateTime.Now.AddDays(1);
            var now = new TestObject() { Date = DateTime.Now };

            var sut = new ComparisonBasedRule<TestObject, DateTime>(x => x.Date, Comparisons.LessThan, tomorrow);

            // assert
            Assert.AreEqual(true, sut.Execute(now).IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_DateTime_Equal()
        {
            // arrange
            var today = DateTime.Now;
            var now = new TestObject() { Date = DateTime.Now };

            var sut = new ComparisonBasedRule<TestObject, DateTime>(x => x.Date, Comparisons.Equal, today);

            // assert
            Assert.AreEqual(true, sut.Execute(now).IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_DateTime_Different()
        {
            // arrange
            var yesterday = DateTime.Now.AddDays(-1);
            var now = new TestObject() { Date = DateTime.Now };

            var sut = new ComparisonBasedRule<TestObject, DateTime>(x => x.Date, Comparisons.Different, yesterday);

            // assert
            Assert.AreEqual(true, sut.Execute(now).IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_DateTime_GreaterThan()
        {
            // arrange
            var yesterday = DateTime.Now.AddDays(-1);
            var now = new TestObject() { Date = DateTime.Now };

            var sut = new ComparisonBasedRule<TestObject, DateTime>(x => x.Date, Comparisons.GreaterThan, yesterday);

            // assert
            Assert.AreEqual(true, sut.Execute(now).IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_DateTime_GreaterThanOrEqual()
        {
            // arrange
            var yesterday = DateTime.Now.AddDays(-1);
            var now = new TestObject() { Date = DateTime.Now };

            var sut = new ComparisonBasedRule<TestObject, DateTime>(x => x.Date, Comparisons.GreaterThanOrEqual, yesterday);

            // assert
            Assert.AreEqual(true, sut.Execute(now).IsSuccess);
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