using System;
using System.Collections.Generic;
using BirthdayGreetingsKata.Solutions;
using Xunit;

namespace BirthdayGreetingsKata.Tests.Solutions
{
    public class BirthdayFilterTests
    {
        [Fact]
        public void NoEmployee()
        {
            var employees = new List<Employee>();

            var result = new BirthdayFilter(employees)
                .Apply(DateTime.Today);

            Assert.Empty(result);
        }

        [Fact]
        public void ManyEmployeesNoBirthday()
        {
            var employees = new List<Employee>
            {
                new Employee(new DateOfBirth(11, 08), new EmailInfo("test1", "test1@test1.com")),
                new Employee(new DateOfBirth(06, 25), new EmailInfo("test2", "test2@test2.com"))
            };

            var result = new BirthdayFilter(employees)
                .Apply(new DateTime(2020, 10, 21));

            Assert.Empty(result);
        }

        [Fact]
        public void ManyEmployeesManyBirthdays()
        {
            var employee1 = new Employee(new DateOfBirth(11, 08), new EmailInfo("test1", "test1@test1.com"));
            var employee2 = new Employee(new DateOfBirth(11, 08), new EmailInfo("test3", "test3@test3.com"));
            var employees = new List<Employee>
            {
                employee1,
                new Employee(new DateOfBirth(06, 25), new EmailInfo("test2", "test2@test2.com")),
                employee2
            };

            var result = new BirthdayFilter(employees)
                .Apply(new DateTime(2020, 11, 08));

            Assert.Equal(new[] {employee1.EmailInfo, employee2.EmailInfo}, result);
        }
    }
}
