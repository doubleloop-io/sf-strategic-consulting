using System.Linq;

namespace BookStore
{
    public class BasketBuilder
    {
        Book[] books;

        public static BasketBuilder aBasket() =>
            new BasketBuilder();


        public static Basket EmptyBasket() =>
            new Basket();

        public BasketBuilder With(params Book[] books)
        {
            this.books = books ?? new Book[0];
            return this;
        }

        public Basket Build()
        {
            var basket = new Basket();
            books.ToList().ForEach(x => basket.Add(x));
            return basket;
        }

        public static implicit operator Basket(BasketBuilder actual) =>
            actual.Build();
    }
}
