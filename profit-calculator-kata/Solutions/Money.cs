using System;

namespace ProfitCalculatorKata.Solutions
{
    public class Money
    {
        readonly int value;
        readonly Currency currency;

        public Money(int value, Currency currency)
        {
            this.value = value;
            this.currency = currency;
        }

        public static Money zero(Currency localCurrency) => new Money(0, localCurrency);

        bool IsLessThen(Money other) => value < other.value;

        public Money Sum(Money other) => Copy(other.value + value);

        public Money Sub(Money money) => Copy(value - money.value);

        public Money Reverse() => Copy(-value);

        public Money Times(double rate) => Copy((int) (value * rate));

        Money Div(double rate) => Copy((int) (value / rate));

        public Money InCurrency(ExchangeRate rates, Currency otherCurrency)
        {
            var exchangeRate = rates.RateFor(currency, otherCurrency);
            if (exchangeRate != null)
                return new Money(Div(exchangeRate).value, otherCurrency);
            return this;
        }

        public bool IsIn(Currency otherCurrency) => otherCurrency == currency;

        Money Copy(int value) => new Money(value, currency);

        public Money Max(Money other)
        {
            if (IsLessThen(other)) return other;
            return this;
        }

        public override string ToString() => $"{nameof(value)}: {value}, {nameof(currency)}: {currency}";

        protected bool Equals(Money other) => value == other.value && Equals(currency, other.currency);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode() => HashCode.Combine(value, currency);

        public static bool operator ==(Money left, Money right) => Equals(left, right);

        public static bool operator !=(Money left, Money right) => !Equals(left, right);
    }
}
