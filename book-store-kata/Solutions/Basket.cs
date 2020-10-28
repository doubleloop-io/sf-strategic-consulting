using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Solutions
{
    public class Basket
    {
        readonly DiscountCalculator discountCalculator;
        readonly Books books;

        public Basket(DiscountCalculator discountCalculator)
        {
            this.discountCalculator = discountCalculator;
            books = new Books();
        }

        public void Add(Book item) =>
            books.Add(item);

        public ICollection<Book> Books =>
            books.All();

        public decimal FullPrice() =>
            RoundDecimal(books.SumOfAllPrices());

        public decimal PriceWithDiscount() =>
            RoundDecimal(discountCalculator.PriceWithDiscount(books));

        static decimal RoundDecimal(decimal number) =>
            Math.Round(number * 100m) / 100.0m;
    }
}
