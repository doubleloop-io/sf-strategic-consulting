using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzKata.Solutions
{
    public class Rules
    {
        readonly List<Rule> rules;

        public Rules(IEnumerable<(int, string)> rules)
            : this(rules.Select(Rule.From))
        { }

        public Rules(IEnumerable<Rule> rules) => 
            this.rules = rules.ToList();

        public IList<string> WordsFor(int number) =>
            rules
                .Select(x => x.WordFor(number))
                .ToList();
    }
}
