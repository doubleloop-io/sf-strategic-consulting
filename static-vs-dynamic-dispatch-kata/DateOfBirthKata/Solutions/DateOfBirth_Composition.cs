using System;

namespace StaticVsDynamicDispatchKata.DateOfBirthKata.Solutions
{
    // NOTE: Common abstraction enables composition
    public interface IDateOfBirth
    {
        bool IsBirthday(DateTime today);
    }

    // NOTE: just an abstraction reification
    public class CommonYear : IDateOfBirth
    {
        readonly int month;
        readonly int day;

        public CommonYear(in int month, in int day)
        {
            this.month = month;
            this.day = day;
        }

        public override string ToString() =>
            $"{nameof(month)}: {month}, {nameof(day)}: {day}";

        public bool IsBirthday(DateTime today) =>
            today.Month == month && today.Day == day;
    }

    // NOTE: another abstraction reification as decorator
    public class LeapYear : IDateOfBirth
    {
        readonly IDateOfBirth inner;

        public LeapYear(IDateOfBirth inner) =>
            this.inner = inner;

        public bool IsBirthday(DateTime today) =>
            !DateTime.IsLeapYear(today.Year)
                ? today.Month == 2 && today.Day == 28
                : inner.IsBirthday(today);
    }

    public static class DateOfBirth_Composition
    {
        public static IDateOfBirth From(DateTime dateOfBirth)
        {
            var commonYear = new CommonYear(dateOfBirth.Month, dateOfBirth.Day);

            return DateTime.IsLeapYear(dateOfBirth.Year)
                ? (IDateOfBirth) new LeapYear(commonYear)
                : commonYear;
        }
    }
}
