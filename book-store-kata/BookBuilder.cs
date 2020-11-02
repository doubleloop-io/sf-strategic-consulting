namespace BookStore
{
    public class BookBuilder
    {
        static readonly string A_NAME = "book name";
        BookType bookType;
        decimal price;

        public BookBuilder(BookType bookType) =>
            this.bookType = bookType;

        public static BookBuilder CookingBook() =>
            new BookBuilder(BookType.COOKING);

        public static BookBuilder ITBook() =>
            new BookBuilder(BookType.IT);

        public static BookBuilder TravelBook() =>
            new BookBuilder(BookType.TRAVEL);

        public static BookBuilder FantasyBook() =>
            new BookBuilder(BookType.FANTASY);

        public BookBuilder Costing(decimal price) {
            this.price = price;
            return this;
        }

        public Book Build() =>
            new Book(A_NAME, bookType, price);

        public static implicit operator Book(BookBuilder actual) =>
            actual.Build();
    }
}
