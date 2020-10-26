using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace BookStore
{
    public class Application
    {
        readonly ITestOutputHelper output;

        public Application(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void LikeMain()
        {
            var fantasy_book_1 = new Book("The Hobbit", BookType.FANTASY, 20.00m);
            var fantasy_book_2 = new Book("Game of Thrones", BookType.FANTASY, 15.00m);
            var it_book_1 = new Book("Software Craftsmanship", BookType.IT, 18.00m);
            var it_book_2 = new Book("GOOS", BookType.IT, 25.00m);
            var it_book_3 = new Book("Clean Code", BookType.IT, 28.00m);
            var travel_book_1 = new Book("Notes from a Small Island", BookType.TRAVEL, 10.00m);
            var cooking_book_1 = new Book("Brazilian Flavours", BookType.COOKING, 10.00m);

            var basket = new Basket();
            basket.Add(fantasy_book_1);
            basket.Add(fantasy_book_2);
            basket.Add(it_book_1);
            basket.Add(it_book_2);
            basket.Add(it_book_3);
            basket.Add(travel_book_1);
            basket.Add(cooking_book_1);

            basket.Books.ToList().ForEach(WriteLine);
            WriteLine($"Full price: {basket.FullPrice()}");
            WriteLine($"Price with discount: {basket.PriceWithDiscount()}");
        }

        void WriteLine(Book book) =>
            output.WriteLine(book.ToString());

        void WriteLine(string message) =>
            output.WriteLine(message);
    }
}
