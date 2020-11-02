using System;
using StaticVsDynamicDispatchKata.PayTermKata.Solutions;

namespace StaticVsDynamicDispatchKata.PayTermKata
{
    public class Invoice_EndOfMonth
    {
        //... a lot of other fields
        readonly DateTimeOffset date;
        readonly IPayTerm payTerm;

        public Invoice_EndOfMonth(DateTimeOffset date, string term, bool isAtEndOfMonth)
        {
            this.date = date;
            payTerm = PayTerm_Composition.ParseData(term, isAtEndOfMonth);
        }

        public DateTimeOffset ExpireDate()
        {
            return payTerm.ComputePayDate(date);
        }
    }
}
