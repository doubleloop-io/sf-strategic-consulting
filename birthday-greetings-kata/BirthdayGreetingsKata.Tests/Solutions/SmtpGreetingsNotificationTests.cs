using System.Net.Mail;
using System.Threading.Tasks;
using BirthdayGreetingsKata.Solutions;
using BirthdayGreetingsKata.Tests.Support;
using netDumbster.smtp;
using Xunit;

namespace BirthdayGreetingsKata.Tests.Solutions
{
    public class SmtpGreetingsNotificationTests
    {
        readonly SmtpConfiguration smtpConfiguration = new SmtpConfiguration
        {
            Sender = "foo@bar.com",
            Host = "localhost",
            Port = 5001
        };

        [Fact]
        public async Task SendBirthday()
        {
            using var smtpServer = SimpleSmtpServer.Start(smtpConfiguration.Port);
            using var notification = new SmtpGreetingsNotification(smtpConfiguration);

            await notification.SendBirthday(
                new[]
                {
                    new EmailInfo("foo", "a@a.com")
                });

            var mail = Assert.Single(ReceivedMail.FromAll(smtpServer));
            Assert.Equal(
                new ReceivedMail(
                    smtpConfiguration.Sender,
                    "a@a.com",
                    "Happy birthday!",
                    "Happy birthday, dear foo!"),
                mail);
        }

        [Fact]
        public async Task ServerUnreachable()
        {
            using var smtpServer = SimpleSmtpServer.Start(smtpConfiguration.Port);
            using var notification = new SmtpGreetingsNotification(smtpConfiguration);

            smtpServer.Stop();

            var ex = await Assert.ThrowsAsync<SmtpException>(
                () =>
                    notification.SendBirthday(
                        new[]
                        {
                            new EmailInfo("foo", "a@a.com")
                        }));
            Assert.Equal(SmtpStatusCode.GeneralFailure, ex.StatusCode);
        }
    }
}
