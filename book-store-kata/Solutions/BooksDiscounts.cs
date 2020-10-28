using System.Collections.Generic;

namespace BookStore.Solutions
{
    public interface IBooksDiscount
    {
        decimal PriceWithDiscount(Books books);
    }

    public class FantasyBooksDiscount : IBooksDiscount
    {
        public decimal PriceWithDiscount(Books books) => books.TotalPriceForBooksOfType(BookType.FANTASY) * 0.8m;
    }

    public class ITBooksDiscount : IBooksDiscount
    {
        public decimal PriceWithDiscount(Books books)
        {
            decimal discount = 1;
            decimal number_of_books = books.NumberOfBooksOfType(BookType.IT);

            if (number_of_books > 2)
                discount = 0.7m; // 30% priceWithDiscount when buying more than 2 IT books
            else if (number_of_books > 0) discount = 0.9m; // 10% priceWithDiscount when buying up to 2 IT books

            return books.TotalPriceForBooksOfType(BookType.IT) * discount;
        }
    }

    public class TravelBooksDiscount : IBooksDiscount
    {
        public decimal PriceWithDiscount(Books books)
        {
            decimal travel_books_discount = 1;

            if (books.NumberOfBooksOfType(BookType.TRAVEL) > 3) travel_books_discount = 0.6m; // 40% priceWithDiscount when buying more than 3 travel books

            return books.TotalPriceForBooksOfType(BookType.TRAVEL) * travel_books_discount;
        }
    }

    public class NoDiscountBooks : IBooksDiscount
    {
        public decimal PriceWithDiscount(Books books)
        {
            return books.TotalPriceForBooksNotOfTypes(BookType.IT, BookType.TRAVEL, BookType.FANTASY);
        }
    }

    public static class BookDiscounts
    {
        public static readonly IBooksDiscount IT = new ITBooksDiscount();
        public static readonly IBooksDiscount Travel = new TravelBooksDiscount();
        public static readonly IBooksDiscount Fantasy = new FantasyBooksDiscount();
        public static readonly IBooksDiscount Nope = new NoDiscountBooks();

        public static IEnumerable<IBooksDiscount> All()
        {
            yield return IT;
            yield return Travel;
            yield return Fantasy;
            yield return Nope;
        }
    }
}
