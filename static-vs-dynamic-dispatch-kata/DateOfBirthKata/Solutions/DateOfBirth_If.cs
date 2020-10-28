using System;

namespace StaticVsDynamicDispatchKata.DateOfBirthKata.Solutions
{
    public sealed class DateOfBirth_If
    {
        readonly int month;
        readonly int day;
        readonly bool isBornOnLeapYear;

        public DateOfBirth_If(in int month, in int day)
        {
            this.month = month;
            this.day = day;
            isBornOnLeapYear = this.month == 2 && this.day == 29;
        }

        public override string ToString() =>
            $"{nameof(month)}: {month}, {nameof(day)}: {day}";

        public bool IsBirthday(DateTime today) =>
            isBornOnLeapYear && IsCommonYear(today)
                ? CheckLeapCase(today)
                : CheckCommonCase(today);

        static bool IsCommonYear(DateTime today) =>
            !DateTime.IsLeapYear(today.Year);

        static bool CheckLeapCase(DateTime today) =>
            today.Month == 2 && today.Day == 28;

        bool CheckCommonCase(DateTime today) =>
            today.Month == month && today.Day == day;

        public static DateOfBirth_If From(DateTime dateOfBirth) =>
            new DateOfBirth_If(dateOfBirth.Month, dateOfBirth.Day);
    }
}
