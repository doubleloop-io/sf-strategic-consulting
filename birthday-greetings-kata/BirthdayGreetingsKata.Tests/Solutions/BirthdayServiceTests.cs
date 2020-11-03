using System;
using System.Threading.Tasks;
using BirthdayGreetingsKata.Solutions;
using Xunit;

namespace BirthdayGreetingsKata.Tests.Solutions
{
    public class BirthdayServiceTests
    {
        [Fact]
        public async Task SendOneGreetingWhenOneBirthday()
        {
            var emailInfo = new EmailInfo("May", "mary.ann@foobar.com");
            var employeeCatalog = new InMemoryEmployeeCatalog(
                new Employee(
                    new DateOfBirth(11, 09),
                    emailInfo
                )
            );
            var greetingsNotification = new InMemoryGreetingsNotification();
            var service = new BirthdayService(employeeCatalog, greetingsNotification);

            await service.SendGreetings(new DateTime(2020, 11, 09));

            Assert.Equal(new[] {emailInfo}, greetingsNotification.ReceivedEmails);
        }

        [Fact]
        public async Task NoSendsGreetingWhenNoBirthdays()
        {
            var emailInfo = new EmailInfo("May", "mary.ann@foobar.com");
            var employeeCatalog = new InMemoryEmployeeCatalog(
                new Employee(
                    new DateOfBirth(11, 09),
                    emailInfo
                )
            );
            var greetingsNotification = new InMemoryGreetingsNotification();
            var service = new BirthdayService(employeeCatalog, greetingsNotification);

            await service.SendGreetings(new DateTime(2020, 12, 25));

            Assert.Empty(greetingsNotification.ReceivedEmails);
        }

        [Fact]
        public async Task SendManyGreetingsWhenManyBirthdays()
        {
            var matteo = new EmailInfo("Matteo", "test@test.com");
            var mary = new EmailInfo("May", "mary.ann@foobar.com");
            var employeeCatalog = new InMemoryEmployeeCatalog(
                new Employee(new DateOfBirth(11, 08), matteo),
                new Employee(new DateOfBirth(10, 29), new EmailInfo("John", "john.doe@foobar.com")),
                new Employee(new DateOfBirth(11, 08), mary)
            );
            var greetingsNotification = new InMemoryGreetingsNotification();
            var service = new BirthdayService(employeeCatalog, greetingsNotification);

            await service.SendGreetings(new DateTime(2020, 11, 08));

            Assert.Equal(new[] {matteo, mary}, greetingsNotification.ReceivedEmails);
        }
    }
}
