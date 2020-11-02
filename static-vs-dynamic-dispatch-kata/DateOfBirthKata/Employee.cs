using System;
using StaticVsDynamicDispatchKata.DateOfBirthKata.Solutions;

namespace StaticVsDynamicDispatchKata.DateOfBirthKata
{
    // Extract class => Primitive Obsession
    public class Employee
    {
        readonly string name;
        readonly IDateOfBirth dateOfBirth;

        public Employee(string name, DateTime dateOfBirth)
        {
            this.name = name;
            this.dateOfBirth = DateOfBirth_Composition.From(dateOfBirth);
        }

        public bool IsBirthday(DateTime today) =>
            dateOfBirth.IsBirthday(today);
    }
}
