using System;
using Xunit;

namespace StaticVsDynamicDispatchKata.DateOfBirthKata
{
    public class EmployeeTests
    {
        [Fact]
        public void BornOnCommonYearAndTodayIsBirthday()
        {
            var employee = new Employee("any", new DateTime(1982, 11, 8));
            Assert.True(employee.IsBirthday(new DateTime(2020, 11, 8)));
        }

        [Fact]
        public void BornOnCommonYearAndTodayIsNotBirthday()
        {
            var employee = new Employee("any", new DateTime(1982, 11, 8));
            Assert.False(employee.IsBirthday(new DateTime(2020, 1, 18)));
        }

        [Fact(Skip = "TODO")]
        public void BornOnLeapYearAndTodayIsBirthdayOnCommonYear()
        {
            var employee = new Employee("any", new DateTime(1996, 2, 29));
            Assert.True(employee.IsBirthday(new DateTime(2019, 2, 28)));
        }

        [Fact(Skip = "TODO")]
        public void BornOnLeapYearAndTodayIsBirthdayOnLeapYear()
        {
            var employee = new Employee("any", new DateTime(1996, 2, 29));
            Assert.True(employee.IsBirthday(new DateTime(2020, 2, 29)));
        }

        [Fact(Skip = "TODO")]
        public void BornOnLeapYearAndTodayIsNotBirthdayOnLeapYear()
        {
            var employee = new Employee("any", new DateTime(1996, 2, 29));
            Assert.False(employee.IsBirthday(new DateTime(2020, 2, 28)));
        }
    }
}
