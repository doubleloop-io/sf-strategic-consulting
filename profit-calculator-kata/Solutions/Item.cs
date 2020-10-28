namespace ProfitCalculatorKata.Solutions
{
    public abstract class Item
    {
        readonly Money amount;

        protected Item(Money amount)
        {
            this.amount = amount;
        }

        public override string ToString() => $"{nameof(amount)}: {amount}";

        public bool IsIn(Currency otherCurrency)
        {
            return amount.IsIn(otherCurrency);
        }

        public Money AmountIn(Currency otherCurrency, ExchangeRate rates)
        {
            return amount.InCurrency(rates, otherCurrency);
        }
    }

    public class Incoming : Item
    {
        public Incoming(Money amount)
            : base(amount)
        {
        }

        public override string ToString() => $"{base.ToString()}";
    }

    public class Outgoing : Item
    {
        public Outgoing(Money amount)
            : base(amount.Reverse())
        {
        }

        public override string ToString() => $"{base.ToString()}";
    }
}
