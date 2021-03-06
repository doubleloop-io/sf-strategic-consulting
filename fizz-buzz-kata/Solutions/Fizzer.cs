using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzKata.Solutions
{
    // FizzerTests 100%
    // Fizzer
    // =>
    // Fizzer + Rules + Rule (+ Tuple)
    public class Fizzer
    {
        readonly Rules rules;

        public Fizzer(IEnumerable<(int, string)> rules)
        {
            this.rules = new Rules(rules);
        }

        public string ConvertAll(int upperbound = 100) =>
            String.Join(
                Environment.NewLine,
                Enumerable.Range(1, upperbound).Select(Convert)
            );

        public string Convert(int n)
        {
            var word = String.Join("", rules.WordsFor(n));
            return word != String.Empty ? word : n.ToString();
        }
    }
}
