using System;

namespace StaticVsDynamicDispatchKata.PayTermKata.Solutions
{
    public class PayTerm_If
    {
        readonly bool isAtEndOfMonth;
        readonly int days;

        public PayTerm_If(bool isAtEndOfMonth, int days)
        {
            this.isAtEndOfMonth = isAtEndOfMonth;
            this.days = days;
        }

        public DateTimeOffset ComputePayDate(DateTimeOffset date)
        {
            var result = date.AddDays(days).Date;
            if (!isAtEndOfMonth) return result;

            var daysInMonth = DateTime.DaysInMonth(result.Year, result.Month);
            var daysToAdd = daysInMonth - result.Day;
            return result.AddDays(daysToAdd).Date;
        }

        public static PayTerm_If ParseData(string term, bool isAtEndOfMonth)
        {
            if (string.IsNullOrWhiteSpace(term))
                throw new InvalidTermException();
            if (term == "d" && isAtEndOfMonth)
                throw new InvalidTermException();

            return new PayTerm_If(isAtEndOfMonth, Parse(term));
        }

        static int Parse(string term) =>
            term switch
            {
                "d" => 0,
                "t" => 30,
                "s" => 60,
                "n" => 90,
                _ => throw new InvalidOperationException()
            };
    }
}
