using System;

namespace StaticVsDynamicDispatchKata.PayTermKata
{
    public class Invoice_Start
    {
        //... a lot of other fields
        readonly DateTimeOffset date;
        readonly string term;

        public Invoice_Start(DateTimeOffset date, string term)
        {
            if (String.IsNullOrWhiteSpace(term))
                throw new InvalidTermException();

            this.date = date;
            this.term = term;
        }

        public DateTimeOffset ExpireDate()
        {
            var result = date;
            switch (term)
            {
                case "t":
                    result = date.AddDays(30).Date;
                    break;
                case "s":
                    result = date.AddDays(60).Date;
                    break;
                case "n":
                    result = date.AddDays(90).Date;
                    break;
            }
            return result;
        }
    }
}
