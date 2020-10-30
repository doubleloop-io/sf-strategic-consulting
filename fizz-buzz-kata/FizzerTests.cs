using System;
using Xunit;

namespace FizzBuzzKata
{
    public class FizzerTests
    {
        [Theory]
        [InlineData(3)]
        [InlineData(3 * 2)]
        [InlineData(3 * 3)]
        public void ConvertDivisibleByThree(Int32 value)
        {
            var fizzer = new Fizzer();

            var result = fizzer.ToWord(value);

            Assert.Equal("Fizz", result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(5 * 2)]
        [InlineData(5 * 5)]
        public void ConvertDivisibleByFive(Int32 value)
        {
            var fizzer = new Fizzer();

            var result = fizzer.ToWord(value);

            Assert.Equal("Buzz", result);
        }

        [Theory]
        [InlineData(7)]
        [InlineData(7 * 2)]
        public void ConvertDivisibleBySeven(Int32 value)
        {
            var fizzer = new Fizzer();

            var result = fizzer.ToWord(value);

            Assert.Equal("Yo", result);
        }

        [Theory]
        [InlineData(5 * 3, "FizzBuzz")]
        [InlineData(5 * 3 * 2, "FizzBuzz")]
        [InlineData(5 * 7, "BuzzYo")]
        public void ConvertDivisibleByMultipleDivisors(Int32 value, string expected)
        {
            var fizzer = new Fizzer();

            var result = fizzer.ToWord(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(2 * 2)]
        [InlineData(11)]
        public void ConvertNotDivisible(Int32 value)
        {
            var fizzer = new Fizzer();

            var result = fizzer.ToWord(value);

            Assert.Equal(value.ToString(), result);
        }

        [Fact]
        public void ConvertAll()
        {
            var fizzer = new Fizzer();

            var result = fizzer.ConvertAll(20);

            Assert.Equal(@"1
2
Fizz
4
Buzz
Fizz
Yo
8
Fizz
Buzz
11
Fizz
13
Yo
FizzBuzz
16
17
Fizz
19
Buzz", result);
        }
    }
}
