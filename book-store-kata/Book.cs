namespace BookStore
{
    public class Book
    {
        public string Name { get; }
        public BookType Type { get; }
        public decimal Price { get; }

        public Book(string name, BookType type, decimal price)
        {
            Name = name;
            Type = type;
            Price = price;
        }

        public override string ToString() => 
            $"{nameof(Name)}: {Name}, {nameof(Type)}: {Type}, {nameof(Price)}: {Price}";
    }
}