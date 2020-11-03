using System;
using BirthdayGreetingsKata.Solutions;
using Xunit;
using static BirthdayGreetingsKata.Tests.Support.EmployeeFile;

namespace BirthdayGreetingsKata.Tests.Solutions
{
    public static class EmployeeFileParserTests
    {
        public class SingleLine
        {
            [Fact]
            public void ValidLine()
            {
                var line = Employee("test", "2020/10/28", "a@a.it");
                var employee = TextFileToEmployeeParser.ParseLine(line);

                Assert.Equal(new Employee(new DateOfBirth(10, 28), new EmailInfo("test", "a@a.it")), employee);
            }

            [Fact]
            public void EmptyLine()
            {
                var line = string.Empty;
                Assert.Throws<MalformedLineException>(() => TextFileToEmployeeParser.ParseLine(line));
            }

            [Fact]
            public void LineWithWrongSeparator()
            {
                var line = WrongSeparator("test", "2020/10/28", "a@a.it");
                Assert.Throws<MalformedLineException>(() => TextFileToEmployeeParser.ParseLine(line));
            }

            [Fact]
            public void MissingSomeData()
            {
                var line = MissingName("2020/10/28", "a@a.it");
                Assert.Throws<MalformedLineException>(() => TextFileToEmployeeParser.ParseLine(line));
            }
        }

        public class ManyLines
        {
            [Fact]
            public void ValidLines()
            {
                var lines = new[]
                {
                    Header(),
                    Employee("test1", "2020/10/28", "a@a.it"),
                    Employee("test2", "2020/10/28", "a@a.it")
                };

                var employees = TextFileToEmployeeParser.ParseLines(lines);

                Assert.Equal(2, employees.Count);
            }

            [Fact]
            public void MissingHeader()
            {
                var lines = new[]
                {
                    Employee("test1", "2020/10/28", "a@a.it"),
                    Employee("test2", "2020/10/28", "a@a.it")
                };

                var employees = TextFileToEmployeeParser.ParseLines(lines);

                Assert.Equal(2, employees.Count);
            }

            [Fact]
            public void OnlyHeader()
            {
                var lines = new[]
                {
                    Header()
                };

                var employees = TextFileToEmployeeParser.ParseLines(lines);

                Assert.Empty(employees);
            }

            [Fact]
            public void DuplicatedLines()
            {
                var lines = new[]
                {
                    Header(),
                    Employee("test", "2020/10/28", "a@a.it"),
                    Employee("test", "2020/10/28", "a@a.it")
                };

                var employees = TextFileToEmployeeParser.ParseLines(lines);

                Assert.Equal(1, employees.Count);
            }
        }
    }
}
