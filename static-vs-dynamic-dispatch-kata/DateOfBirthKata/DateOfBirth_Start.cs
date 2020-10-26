using System;

namespace StaticVsDynamicDispatchKata.DateOfBirthKata
{
    public sealed class DateOfBirth_Start
    {
        readonly int month;
        readonly int day;

        public DateOfBirth_Start(in int month, in int day)
        {
            this.month = month;
            this.day = day;
        }

        public override string ToString() =>
            $"{nameof(month)}: {month}, {nameof(day)}: {day}";

        public bool IsBirthday(DateTime today) =>
            today.Month == month && today.Day == day;

        public static DateOfBirth_Start From(DateTime dateOfBirth) =>
            new DateOfBirth_Start(dateOfBirth.Month, dateOfBirth.Day);
    }
}
