using System;
using System.Globalization;
using System.Threading.Tasks;
using BirthdayGreetingsKata.Tests.Support;
using netDumbster.smtp;
using Xunit;
using static BirthdayGreetingsKata.Tests.Support.EmployeeFile;

namespace BirthdayGreetingsKata.Tests
{
    public class AppTests : IDisposable
    {
        readonly GreetingsApp app;

        readonly FileConfiguration fileConfiguration = new FileConfiguration
        {
            FilePath = $"employees-{nameof(AppTests)}.txt"
        };

        readonly SmtpConfiguration smtpConfiguration = new SmtpConfiguration
        {
            Sender = "foo@bar.com",
            Host = "localhost",
            Port = 8000
        };

        readonly SimpleSmtpServer smtpServer;

        public AppTests()
        {
            smtpServer = SimpleSmtpServer.Start(smtpConfiguration.Port);
            app = new GreetingsApp(fileConfiguration, smtpConfiguration);
        }

        public void Dispose() =>
            smtpServer.Dispose();

        [Fact]
        public async Task SendOneGreetingWhenOneBirthday()
        {
            File(fileConfiguration.FilePath, Header(), Employee("Mary", "1975/09/11", "mary.ann@foobar.com"));

            await app.Run(Date("11/09/2020"));

            var received = Assert.Single(ReceivedMail.FromAll(smtpServer));
            Assert.Equal(
                new ReceivedMail(
                    smtpConfiguration.Sender,
                    "mary.ann@foobar.com",
                    "Happy birthday!",
                    "Happy birthday, dear Mary!"),
                received);
        }

        [Fact]
        public async Task NoSendsGreetingWhenNoBirthdays()
        {
            File(fileConfiguration.FilePath, Header(), Employee("Mary", "1982/11/08", "mary.ann@foobar.com"));

            await app.Run(Date("11/09/2020"));

            Assert.Empty(ReceivedMail.FromAll(smtpServer));
        }

        [Fact]
        public async Task SendManyGreetingsWhenManyBirthdays()
        {
            File(
                fileConfiguration.FilePath,
                Header(),
                Employee("Matteo", "1982/09/11", "matteo@doubleloop.io"),
                Employee("John", "1982/10/08", "john.doe@foobar.com"),
                Employee("Mary", "1975/09/11", "mary.ann@foobar.com"));

            await app.Run(Date("11/09/2020"));

            Assert.Equal(
                Received(
                    new ReceivedMail(
                        smtpConfiguration.Sender,
                        "mary.ann@foobar.com",
                        "Happy birthday!",
                        "Happy birthday, dear Mary!"),
                    new ReceivedMail(
                        smtpConfiguration.Sender,
                        "matteo@doubleloop.io",
                        "Happy birthday!",
                        "Happy birthday, dear Matteo!")
                ),
                ReceivedMail.FromAll(smtpServer));
        }

        static ReceivedMail[] Received(params ReceivedMail[] mails) =>
            mails ?? new ReceivedMail[0];

        static DateTime Date(string value) =>
            DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
    }
}
