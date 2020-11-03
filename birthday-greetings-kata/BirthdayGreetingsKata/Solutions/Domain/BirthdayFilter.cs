using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayGreetingsKata.Solutions
{
    public class BirthdayFilter
    {
        readonly IList<Employee> employees;

        public BirthdayFilter(IList<Employee> employees) =>
            this.employees = employees;

        public IList<EmailInfo> Apply(DateTime today) =>
            employees
                .Where(x => x.DateOfBirth.IsBirthday(today))
                .Select(x => x.EmailInfo)
                .ToList();
    }
}
