using System.Collections.Generic;
using System.Linq;

namespace BookStore.Solutions
{
    public class DiscountCalculator
    {
        readonly IList<IBooksDiscount> discounts;

        public DiscountCalculator()
            : this(BookDiscounts.All().ToList())
        {
        }

        public DiscountCalculator(IList<IBooksDiscount> discounts) =>
            this.discounts = discounts;

        public decimal PriceWithDiscount(Books books) =>
            discounts
                .Select(bd => bd.PriceWithDiscount(books))
                .Sum();
    }
}
