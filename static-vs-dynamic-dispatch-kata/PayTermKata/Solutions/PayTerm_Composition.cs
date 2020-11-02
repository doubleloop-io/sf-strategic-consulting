using System;
using System.Linq;

namespace StaticVsDynamicDispatchKata.PayTermKata.Solutions
{
    // NOTE: Common abstraction enables composition
    public interface IPayTerm
    {
        DateTimeOffset ComputePayDate(DateTimeOffset date);
    }

    // NOTE: just an abstraction reification
    public class SameDate : IPayTerm
    {
        public DateTimeOffset ComputePayDate(DateTimeOffset date) =>
            date;
    }

    // NOTE: just an abstraction reification
    public class AddDays : IPayTerm
    {
        readonly int days;

        public AddDays(int days) =>
            this.days = days;

        public DateTimeOffset ComputePayDate(DateTimeOffset date) =>
            date.AddDays(days).Date;
    }

    // NOTE: just an abstraction reification
    public class ShiftToEndOfMonth : IPayTerm
    {
        public DateTimeOffset ComputePayDate(DateTimeOffset date)
        {
            var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            var daysToAdd = daysInMonth - date.Day;
            return date.AddDays(daysToAdd).Date;
        }
    }

    // NOTE: another abstraction reification as composite pattern
    public class AndPayTerms : IPayTerm
    {
        readonly IPayTerm[] terms;

        public AndPayTerms(params IPayTerm[] terms) =>
            this.terms = terms ?? new IPayTerm[0];

        public DateTimeOffset ComputePayDate(DateTimeOffset date) =>
            terms.Aggregate(date, (acc, cur) => cur.ComputePayDate(acc));
    }

    public static class PayTerm_Composition
    {
        public static IPayTerm ParseData(string term, bool isAtEndOfMonth)
        {
            if (string.IsNullOrWhiteSpace(term))
                throw new InvalidTermException();
            if (term == "d" && isAtEndOfMonth)
                throw new InvalidTermException();

            if (term == "d") return new SameDate();

            var baseTerm = Parse(term);
            var shiftToEndOfMonth = isAtEndOfMonth ? (IPayTerm) new ShiftToEndOfMonth() : new SameDate();
            return new AndPayTerms(baseTerm, shiftToEndOfMonth);
        }

        static IPayTerm Parse(string term) =>
            new AddDays(
                term switch
                {
                    "t" => 30,
                    "s" => 60,
                    "n" => 90,
                    _ => throw new InvalidOperationException()
                });
    }
}
