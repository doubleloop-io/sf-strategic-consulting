using System.Threading.Tasks;
using BirthdayGreetingsKata.Solutions;
using Xunit;
using static BirthdayGreetingsKata.Tests.Support.EmployeeFile;

namespace BirthdayGreetingsKata.Tests.Solutions
{
    public class TextFileEmployeeCatalogTests
    {
        readonly FileConfiguration fileConfiguration = new FileConfiguration
        {
            FilePath = $"employees-{nameof(TextFileEmployeeCatalogTests)}.txt"
        };

        [Fact]
        public async Task LoadEmployees()
        {
            File(
                fileConfiguration.FilePath,
                Header(),
                Employee("test", "2020/10/28", "a@a.it"),
                Employee("Mary", "1982/11/08", "mary.ann@foobar.com"));
            var employeeCatalog = new TextFileEmployeeCatalog(fileConfiguration);

            var employees = await employeeCatalog.Load();

            Assert.Equal(
                new[]
                {
                    new Employee(new DateOfBirth(10, 28), new EmailInfo("test", "a@a.it")),
                    new Employee(new DateOfBirth(11, 08), new EmailInfo("Mary", "mary.ann@foobar.com"))
                },
                employees
            );
        }

        [Fact]
        public async Task MissingFile()
        {
            DeleteFile(fileConfiguration.FilePath);
            var employeeCatalog = new TextFileEmployeeCatalog(fileConfiguration);

            var employees = await employeeCatalog.Load();

            Assert.Empty(employees);
        }
    }
}
