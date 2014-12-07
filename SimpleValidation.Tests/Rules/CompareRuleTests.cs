using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleValidation.Builders;
using SimpleValidation.Rules;

namespace SimpleValidation.Tests.Rules
{
    [TestClass]
    public class CompareRuleTests
    {
        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_DateTime_LessThan()
        {
            // arrange
            var tomorrow = DateTime.Now.AddDays(1);
            var now = new TestObject() { Date = DateTime.Now };

            var sut = new CompareRule<DateTime>(Comparisons.LessThan, tomorrow);

            // assert
            Assert.AreEqual(true, sut.Execute(now.Date).IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_DateTime_LessThanOrEqual()
        {
            // arrange
            var tomorrow = DateTime.Now.AddDays(1);
            var now = new TestObject() { Date = DateTime.Now };

            var sut = new CompareRule<DateTime>(Comparisons.LessThan, tomorrow);

            // assert
            Assert.AreEqual(true, sut.Execute(now.Date).IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_DateTime_Equal()
        {
            // arrange
            var today = DateTime.Now;
            var now = new TestObject() { Date = DateTime.Now };

            var sut = new CompareRule<DateTime>(Comparisons.Equal, today);

            // assert
            Assert.AreEqual(true, sut.Execute(now.Date).IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_DateTime_Different()
        {
            // arrange
            var yesterday = DateTime.Now.AddDays(-1);
            var now = new TestObject() { Date = DateTime.Now };

            var sut = new CompareRule<DateTime>(Comparisons.Different, yesterday);

            // assert
            Assert.AreEqual(true, sut.Execute(now.Date).IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_DateTime_GreaterThan()
        {
            // arrange
            var yesterday = DateTime.Now.AddDays(-1);
            var now = new TestObject() { Date = DateTime.Now };

            var sut = new CompareRule<DateTime>(Comparisons.GreaterThan, yesterday);

            // assert
            Assert.AreEqual(true, sut.Execute(now.Date).IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_DateTime_GreaterThanOrEqual()
        {
            // arrange
            var yesterday = DateTime.Now.AddDays(-1);
            var now = new TestObject() { Date = DateTime.Now };

            var sut = new CompareRule<DateTime>(Comparisons.GreaterThanOrEqual, yesterday);

            // assert
            Assert.AreEqual(true, sut.Execute(now.Date).IsSuccess);
        }

        [TestMethod]
        public void Execute_must_return_correct_ValidationResult_for_null_values()
        {
            // arrange
            var reference = new TestObject() { String = null };
            string comparison = null;

            var sut = new CompareRule<string>(Comparisons.LessThan, comparison);

            // assert
            Assert.AreEqual(false, sut.Execute(reference.String).IsSuccess);
        }
    }
}