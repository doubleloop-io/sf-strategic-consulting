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

            var result = fizzer.Convert(value);

            Assert.Equal("Fizz", result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(5 * 2)]
        [InlineData(5 * 5)]
        public void ConvertDivisibleByFive(Int32 value)
        {
            var fizzer = new Fizzer();

            var result = fizzer.Convert(value);

            Assert.Equal("Buzz", result);
        }

        [Theory]
        [InlineData(5 * 3)]
        [InlineData(5 * 3 * 2)]
        public void ConvertDivisibleByThreeAndFive(Int32 value)
        {
            var fizzer = new Fizzer();

            var result = fizzer.Convert(value);

            Assert.Equal("FizzBuzz", result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(2 * 2)]
        [InlineData(7)]
        public void ConvertNotDivisible(Int32 value)
        {
            var fizzer = new Fizzer();

            var result = fizzer.Convert(value);

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
7
8
Fizz
Buzz
11
Fizz
13
14
FizzBuzz
16
17
Fizz
19
Buzz", result);
        }
    }
}
