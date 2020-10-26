using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore
{
    public class Basket
    {
        readonly List<Book> books;

        public Basket() =>
            books = new List<Book>();

        public void Add(Book item) =>
            books.Add(item);

        public ICollection<Book> Books =>
            new List<Book>(books);

        public decimal FullPrice() =>
            books.Aggregate(0m, (tot, cur) => tot + cur.Price);

        public decimal PriceWithDiscount()
        {
            decimal it_books_discount = 0;
            decimal travel_books_discount = 0;
            decimal number_of_it_books = 0;
            decimal number_of_travel_books = 0;
            decimal total_price_for_it_books = 0;
            decimal total_price_for_travel_books = 0;
            decimal total_price_for_other_books = 0;

            foreach (var book in books)
            {
                if (book.Type == BookType.IT)
                {
                    number_of_it_books += 1;
                    total_price_for_it_books += book.Price;
                }
                else if (book.Type == BookType.TRAVEL)
                {
                    number_of_travel_books += 1;
                    total_price_for_travel_books += book.Price;
                }
                else
                {
                    total_price_for_other_books += book.Price;
                }
            }

            if (number_of_it_books > 2)
            {
                it_books_discount = 0.7m; // 30% discount when buying more than 2 IT books
            }
            else if (number_of_it_books > 0)
            {
                it_books_discount = 0.9m; // 10% discount when buying up to 2 IT books
            }

            if (number_of_travel_books > 3)
            {
                travel_books_discount = 0.6m; // 40% discount when buying more than 3 travel books
            }

            if (travel_books_discount > 0)
            {
                total_price_for_travel_books *= travel_books_discount;
            }

            return RoundDecimal(
                total_price_for_it_books * it_books_discount
                + total_price_for_travel_books
                + total_price_for_other_books);
        }

        static decimal RoundDecimal(decimal number) =>
            Math.Round(number * 100m) / 100.0m;
    }
}
