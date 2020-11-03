using System.Net.Mail;
using System.Threading.Tasks;

namespace BirthdayGreetingsKata
{
    public class SmtpGreetingsAdapter : IGreetingsPort
    {
        public SmtpConfiguration SmtpConfiguration { get; }
        public SmtpClient SmtpClient { get; }

        public SmtpGreetingsAdapter(SmtpConfiguration smtpConfiguration, SmtpClient smtpClient)
        {
            SmtpConfiguration = smtpConfiguration;
            SmtpClient = smtpClient;
        }

        public async Task Publish(EmployeeInfo birthday)
        {
            await this.SmtpClient.SendMailAsync(
                this.SmtpConfiguration.Sender,
                birthday.Email,
                "Happy birthday!",
                $"Happy birthday, dear {birthday.Name}!");
        }
    }
}