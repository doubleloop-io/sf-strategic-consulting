using System.Collections.Generic;
using System.Linq;

namespace BookStore.Solutions
{
    public class Books
    {
        readonly IList<Book> bookList = new List<Book>();

        public void Add(Book book) => bookList.Add(book);

        public List<Book> All() => new List<Book>(bookList);

        public int NumberOfBooksOfType(BookType type) => BooksOfType(type).Count();

        public decimal TotalPriceForBooksOfType(BookType type) => PricesOf(BooksOfType(type)).Sum();
        public decimal TotalPriceForBooksNotOfTypes(params BookType[] bookTypes) => PricesOf(BooksNotOfTypes(bookTypes ?? new BookType[0])).Sum();

        public decimal SumOfAllPrices() => PricesOf(bookList).Sum();

        static IEnumerable<decimal> PricesOf(IEnumerable<Book> books) => books.Select(b => b.Price);

        IEnumerable<Book> BooksOfType(BookType type) => bookList.Where(b => type == b.Type);
        IEnumerable<Book> BooksNotOfTypes(BookType[] types) => bookList.Where(b => !types.Contains(b.Type));
    }
}
