using System.Collections.Generic;
using Xunit;
using static ProfitCalculatorKata.Solutions.Currencies;

namespace ProfitCalculatorKata.Solutions
{
    public class ProfitCalculatorTest
    {
        static readonly ExchangeRate rates = new ExchangeRate(
            new Dictionary<Currency, double>
            {
                {GBP, 1.0},
                {USD, 1.6},
                {EUR, 1.2}
            });

        readonly ProfitCalculator gbpCalculator = new ProfitCalculator(GBP, rates);
        readonly ProfitCalculator eurCalculator = new ProfitCalculator(EUR, rates);

        [Fact]
        public void calculates_the_tax_at_20_percent()
        {
            gbpCalculator.Add(new Incoming(new Money(500, GBP)));

            var profit = gbpCalculator.Profit();
            var tax = gbpCalculator.Tax();

            Assert.Equal(new Money(400, GBP), profit);
            Assert.Equal(new Money(100, GBP), tax);
        }

        [Fact]
        public void calculates_the_tax_of_multiple_amounts()
        {
            gbpCalculator.Add(new Incoming(new Money(120, GBP)));
            gbpCalculator.Add(new Incoming(new Money(200, GBP)));

            var profit = gbpCalculator.Profit();
            var tax = gbpCalculator.Tax();

            Assert.Equal(new Money(256, GBP), profit);
            Assert.Equal(new Money(64, GBP), tax);
        }

        [Fact]
        public void different_currencies_are_not_taxed()
        {
            gbpCalculator.Add(new Incoming(new Money(120, GBP)));
            gbpCalculator.Add(new Incoming(new Money(200, USD)));

            var profit = gbpCalculator.Profit();
            var tax = gbpCalculator.Tax();

            Assert.Equal(new Money(221, GBP), profit);
            Assert.Equal(new Money(24, GBP), tax);
        }

        [Fact]
        public void handle_outgoings()
        {
            gbpCalculator.Add(new Incoming(new Money(500, GBP)));
            gbpCalculator.Add(new Incoming(new Money(80, USD)));
            gbpCalculator.Add(new Outgoing(new Money(360, EUR)));

            var profit = gbpCalculator.Profit();
            var tax = gbpCalculator.Tax();

            Assert.Equal(new Money(150, GBP), profit);
            Assert.Equal(new Money(100, GBP), tax);
        }

        [Fact]
        public void a_negative_balance_results_in_no_tax()
        {
            gbpCalculator.Add(new Incoming(new Money(500, GBP)));
            gbpCalculator.Add(new Outgoing(new Money(200, GBP)));
            gbpCalculator.Add(new Outgoing(new Money(400, GBP)));
            gbpCalculator.Add(new Outgoing(new Money(20, GBP)));

            var profit = gbpCalculator.Profit();
            var tax = gbpCalculator.Tax();

            Assert.Equal(new Money(-120, GBP), profit);
            Assert.Equal(new Money(0, GBP), tax);
        }

        [Fact]
        public void everything_reported_in_the_local_currency()
        {
            eurCalculator.Add(new Incoming(new Money(400, GBP)));
            eurCalculator.Add(new Outgoing(new Money(200, USD)));
            eurCalculator.Add(new Incoming(new Money(200, EUR)));

            var profit = eurCalculator.Profit();
            var tax = eurCalculator.Tax();

            Assert.Equal(new Money(491, EUR), profit);
            Assert.Equal(new Money(40, EUR), tax);
        }
    }
}
