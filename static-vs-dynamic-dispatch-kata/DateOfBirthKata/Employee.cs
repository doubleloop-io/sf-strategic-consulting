using System;

namespace StaticVsDynamicDispatchKata.DateOfBirthKata
{
    public class Employee
    {
        readonly string name;
        readonly DateTime dateOfBirth;

        public Employee(string name, DateTime dateOfBirth)
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
        }

        public bool IsBirthday(DateTime today) =>
            today.Month == dateOfBirth.Month && today.Day == dateOfBirth.Day;
    }
}
