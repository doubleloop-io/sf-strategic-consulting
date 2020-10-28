namespace ProfitCalculatorKata.Solutions
{
    public class ProfitCalculator
    {
        readonly Currency localCurrency;
        readonly ExchangeRate rates;
        readonly Items items;

        public ProfitCalculator(Currency localCurrency, ExchangeRate rates)
        {
            items = Items.Empty();
            this.localCurrency = localCurrency;
            this.rates = rates;
        }

        public void Add(Item item)
        {
            items.Add(item);
        }

        public Money Profit() =>
            LocalAmount()
                .Sub(Tax())
                .Sum(ForeignAmount());

        public Money Tax() =>
            LocalAmount()
                .Max(Money.zero(localCurrency))
                .Times(0.2);

        Money LocalAmount() =>
            items
                .TakeAll(localCurrency)
                .TotalIn(localCurrency, rates);

        Money ForeignAmount() =>
            items
                .DropAll(localCurrency)
                .TotalIn(localCurrency, rates);
    }
}
