using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleValidation.Builders;

namespace SimpleValidation.Tests
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public void ValidatorBuilder_api()
        {
            // arrange
            var success = new TestObject()
            {
                String = "Test",
                Date = DateTime.Now.AddDays(-1),
                Parent = new TestObject()
                {
                    Date = DateTime.Now.AddDays(1)
                }
            };

            var rules = new List<ITargetedRule<TestObject>>();

            var sut = new ValidatorBuilder<TestObject>(rules)
                .RuleFor(x => x.String)
                    .NotDefault()
                    .NotWhitespace()
                .RuleFor(x => x.Date)
                    .NotDefault()
                    .LessThanToday()
                .RuleFor(x => x.Parent).NotDefault()
                    .RuleFor(x => x.Parent.Date)
                        .NotDefault()
                        .GreaterThanToday();

            // act
            var successResults = rules.Select(x => x.Execute(success));

            // assert
            Assert.IsTrue(successResults.All(x => x.IsSuccess));
        }
    }
}