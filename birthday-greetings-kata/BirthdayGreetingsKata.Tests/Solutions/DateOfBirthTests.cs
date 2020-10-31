using System;
using BirthdayGreetingsKata.Solutions;
using Xunit;

namespace BirthdayGreetingsKata.Tests.Solutions
{
    public class DateOfBirthTests
    {
        [Fact]
        public void Equally()
        {
            var original = new DateOfBirth(1, 1);
            var same = new DateOfBirth(1, 1);
            var differentMonth = new DateOfBirth(2, 1);
            var differentDay = new DateOfBirth(1, 2);

            Assert.Equal(original, same);
            Assert.NotEqual(original, differentMonth);
            Assert.NotEqual(original, differentDay);
        }

        [Theory]
        [InlineData(2020)]
        [InlineData(2019)]
        public void YesBirthday(int year)
        {
            var dateOfBirth = new DateOfBirth(11, 8);
            Assert.True(dateOfBirth.IsBirthday(new DateTime(year, 11, 8)));
        }

        [Theory]
        [InlineData(12, 8)]
        [InlineData(11, 9)]
        public void NoBirthday(int month, int day)
        {
            var dateOfBirth = new DateOfBirth(11, 8);
            Assert.False(dateOfBirth.IsBirthday(new DateTime(2020, month, day)));
        }

        [Fact]
        public void BornOnLeapYearAndCheckYesBirthdayOnCommonYear()
        {
            var dateOfBirth = new DateOfBirth(2, 29);
            Assert.True(dateOfBirth.IsBirthday(new DateTime(2019, 2, 28)));
        }

        [Fact]
        public void BornOnLeapYearAndCheckNoBirthdayOnLeapYear()
        {
            var dateOfBirth = new DateOfBirth(2, 29);
            Assert.False(dateOfBirth.IsBirthday(new DateTime(2020, 2, 28)));
        }

        [Fact]
        public void BornOnLeapYearAndCheckYesBirthdayOnLeapYear()
        {
            var dateOfBirth = new DateOfBirth(2, 29);
            Assert.True(dateOfBirth.IsBirthday(new DateTime(2020, 2, 29)));
        }
    }
}