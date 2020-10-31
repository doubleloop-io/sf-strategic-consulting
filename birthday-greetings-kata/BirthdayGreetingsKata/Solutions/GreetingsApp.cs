using System;
using System.Threading.Tasks;

namespace BirthdayGreetingsKata.Solutions
{
    public class GreetingsApp : IDisposable
    {
        readonly TextFileEmployeeCatalog employeeCatalog;
        readonly SmtpGreetingsNotification smtpGreetingsNotification;
        readonly BirthdayService birthdayService;

        public GreetingsApp(FileConfiguration fileConfiguration, SmtpConfiguration smtpConfiguration)
        {
            smtpGreetingsNotification = new SmtpGreetingsNotification(smtpConfiguration);
            employeeCatalog = new TextFileEmployeeCatalog(fileConfiguration);
            birthdayService = new BirthdayService(employeeCatalog, smtpGreetingsNotification);
        }

        public void Dispose() =>
            smtpGreetingsNotification?.Dispose();

        public Task RunOnToday() =>
            Run(DateTime.Today);

        public async Task Run(DateTime today) => await birthdayService.SendGreetings(today);
    }
}
