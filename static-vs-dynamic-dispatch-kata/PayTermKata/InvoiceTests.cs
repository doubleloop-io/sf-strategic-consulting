using System;
using System.Globalization;
using Xunit;

namespace StaticVsDynamicDispatchKata.PayTermKata
{
    public class InvoiceTests
    {
        [Fact]
        public void ThirtyTerm()
        {
            var invoice = new Invoice(Date("09/02/2015"), "t", false);
            Assert.Equal(Date("11/03/2015"), invoice.ExpireDate());
        }

        [Fact]
        public void SixtyTerm()
        {
            var invoice = new Invoice(Date("09/02/2015"), "s", false);
            Assert.Equal(Date("10/04/2015"), invoice.ExpireDate());
        }

        [Fact]
        public void NintyTerm()
        {
            var invoice = new Invoice(Date("09/02/2015"), "n", false);
            Assert.Equal(Date("10/05/2015"), invoice.ExpireDate());
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("d", true)]
        public void InvalidTerm(string term, bool endOfMonth)
        {
            Assert.Throws<InvalidTermException>(() => new Invoice(Date("09/02/2015"), term, endOfMonth));
        }

        [Fact]
        public void Direct()
        {
            var invoice = new Invoice(Date("09/02/2015"), "d", false);
            Assert.Equal(Date("09/02/2015"), invoice.ExpireDate());
        }

        [Fact]
        public void AtTheEndOfMonth()
        {
            var invoice = new Invoice(Date("09/02/2015"), "s", true);
            Assert.Equal(Date("30/04/2015"), invoice.ExpireDate());
        }

        static DateTimeOffset Date(string value) =>
            DateTimeOffset.Parse(value, CultureInfo.GetCultureInfo("it-IT")).Date;
    }
}
