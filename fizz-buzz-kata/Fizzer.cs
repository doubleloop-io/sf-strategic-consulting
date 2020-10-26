using System;
using System.Linq;

namespace FizzBuzzKata
{
    public class Fizzer
    {
        public string Convert(int n)
        {
            if (n % 15 == 0) return "FizzBuzz";
            if (n % 3 == 0) return "Fizz";
            if (n % 5 == 0) return "Buzz";
            return n.ToString();
        }

        public string ConvertAll(int count = 100) =>
            String.Join(Environment.NewLine,
                Enumerable.Range(1, count).Select(Convert)
            );
    }
}
