using System;
using System.Collections.Generic;

namespace ProfitCalculatorKata.Solutions
{
    public class ExchangeRate
    {
        readonly IDictionary<Currency, double> rates;

        public ExchangeRate(IDictionary<Currency, double> rates) => this.rates = rates;

        public double RateFor(Currency currency) =>
            rates[currency];

        public double RateFor(Currency otherCurrency, Currency localCurrency) =>
            RateFor(otherCurrency) / RateFor(localCurrency);

        public void CheckIsDefined(Currency currency)
        {
            if (RateFor(currency) == null)
                throw new ArgumentException($"Invalid currency '{currency}'");
        }
    }
}
