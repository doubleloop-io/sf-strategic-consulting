using System;
using System.Linq;

namespace FizzBuzzKata
{
    public class Fizzer
    {
        // string.from(int)
        // int.ToString()
        // int_string_mapper.map(int)

        public string ToWord(int n)
        {
            // EASY -> banale == perfect match
            // SIMPLE -> strutturata == perfect match
            string word = null;

            if (IsDivisibleBy(n, 3))
                word += "Fizz";

            if (IsDivisibleBy(n, 5))
                word += "Buzz";

            if (IsDivisibleBy(n, 7))
                word += "Yo";

            return String.IsNullOrWhiteSpace(word) ? n.ToString() : word;
        }

        static bool IsDivisibleBy(int n, int divisor) =>
            n % divisor == 0;

        public string ConvertAll(int count = 100) =>
            String.Join(Environment.NewLine,
                Enumerable.Range(1, count).Select(ToWord)
            );
    }
}
