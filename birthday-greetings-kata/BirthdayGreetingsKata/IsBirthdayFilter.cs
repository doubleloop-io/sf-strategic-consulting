using System;
using System.Collections.Generic;

namespace BirthdayGreetingsKata
{
    public class IsBirthdayFilter
    {
        List<EmployeeInfo> Employees { get; }

        public IsBirthdayFilter(List<EmployeeInfo> employees) =>
            Employees = employees;

        public List<EmployeeInfo> Apply(DateTime today)
        {
            var birthdays = new List<EmployeeInfo>();
            foreach (var employee in this.Employees)
            {
                if (employee.DateOfBirth.IsBirthday(today))
                    birthdays.Add(employee);
            }

            return birthdays;
        }
    }
}
