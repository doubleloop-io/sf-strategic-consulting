using System;
using System.Collections.Generic;
using Xunit;

namespace FizzBuzzKata.Solutions
{
    public class FizzerTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(2 * 2)]
        public void ApplyOneConvertRule(int value)
        {
            var rules = new List<(int, string)>
                {(2, "a"), (3, "b")};
            var fizzer = new Fizzer(rules);

            var result = fizzer.Convert(value);

            Assert.Equal("a", result);
        }

        [Theory]
        [InlineData(2, "a")]
        [InlineData(3, "b")]
        [InlineData(5, "c")]
        [InlineData(2 * 3 * 5, "abc")]
        public void ApplyManyConvertRules(int value, string expected)
        {
            var rules = new List<(int, string)>
                {(2, "a"), (3, "b"), (5, "c")};
            var fizzer = new Fizzer(rules);

            var result = fizzer.Convert(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void NoConvertRulesApplied(int value)
        {
            var rules = new List<(int, string)>
                {(2, "Foo")};
            var fizzer = new Fizzer(rules);

            var result = fizzer.Convert(value);

            Assert.Equal(value.ToString(), result);
        }

        [Fact]
        public void ConvertNumberRange()
        {
            var rules = new List<(int, string)>
                {(2, "a")};
            var fizzer = new Fizzer(rules);

            var result = fizzer.ConvertAll(3);

            Assert.Equal(
                @"1
a
3",
                result);
        }
    }
}
