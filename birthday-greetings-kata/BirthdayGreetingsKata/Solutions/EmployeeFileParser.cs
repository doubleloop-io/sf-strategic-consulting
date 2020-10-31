using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayGreetingsKata.Solutions
{
    public static class EmployeeFileParser
    {
        const string HEADER = "last_name, first_name, date_of_birth, email";

        public static List<Employee> ParseLines(string[] lines) =>
            lines
                .Where(NotHeaderLine())
                .Select(ParseLine)
                .Distinct()
                .ToList();

        public static Employee ParseLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                throw new MalformedLineException(line);

            var parts = SplitLine(line);
            if (parts.Length != 4)
                throw new MalformedLineException(line);

            return new Employee(
                DateOfBirth.From(parts[2]),
                new EmailInfo(parts[1], parts[3])
            );
        }

        static Func<string, bool> NotHeaderLine() =>
            x => x != HEADER;

        static string[] SplitLine(string line) =>
            line
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
    }
}
