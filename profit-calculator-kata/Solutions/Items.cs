using System.Collections.Generic;
using System.Linq;

namespace ProfitCalculatorKata.Solutions
{
    public class Items
    {
        readonly IList<Item> items;

        public Items(IList<Item> items) => this.items = items;

        public static Items Empty() => new Items(new List<Item>());

        public void Add(Item item)
        {
            items.Add(item);
        }

        public Items TakeAll(Currency currency)
        {
            return new Items(
                items
                    .Where(i => i.IsIn(currency))
                    .ToList());
        }

        public Items DropAll(Currency currency)
        {
            return new Items(
                items
                    .Where(i => !i.IsIn(currency))
                    .ToList());
        }

        public Money TotalIn(Currency currency, ExchangeRate rates)
        {
            return items
                .Select(item => item.AmountIn(currency, rates))
                .Aggregate(Money.zero(currency), (tot, cur) => tot.Sum(cur));
        }
    }
}
