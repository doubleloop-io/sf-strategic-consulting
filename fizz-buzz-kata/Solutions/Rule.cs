namespace FizzBuzzKata.Solutions
{
    public class Rule
    {
        public int Divisor { get; }
        public string Word { get; }

        public Rule(int divisor, string word)
        {
            Divisor = divisor;
            Word = word;
        }

        public static Rule From((int, string) value) =>
            new Rule(value.Item1, value.Item2);

        public string WordFor(int number) =>
            number % Divisor == 0 ? Word : string.Empty;
    }
}
