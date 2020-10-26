using System;

namespace StaticVsDynamicDispatchKata.PayTermKata
{
    public class Invoice
    {
        //... a lot of other fields
        readonly DateTimeOffset date;
        readonly string term;
        readonly bool isAtEndOfMonth;

        public Invoice(DateTimeOffset date, string term, bool isAtEndOfMonth)
        {
            if (String.IsNullOrWhiteSpace(term))
                throw new InvalidTermException();
            if (term == "d" && isAtEndOfMonth)
                throw new InvalidTermException();

            this.date = date;
            this.term = term;
            this.isAtEndOfMonth = isAtEndOfMonth;
        }

        public DateTimeOffset ExpireDate()
        {
            DateTimeOffset result;
            switch (term)
            {
                case "d":
                    result = date;
                    break;
                case "t":
                    result = date.AddDays(30).Date;
                    break;
                case "s":
                    result = date.AddDays(60).Date;
                    break;
                case "n":
                    result = date.AddDays(90).Date;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            if (isAtEndOfMonth)
            {
                var daysInMonth = DateTime.DaysInMonth(result.Year, result.Month);
                var daysToAdd = daysInMonth - result.Day;
                result = result.AddDays(daysToAdd).Date;
            }

            return result;
        }
    }
}
