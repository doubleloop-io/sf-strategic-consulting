using System.Collections.Generic;
using System.Threading.Tasks;
using BirthdayGreetingsKata.Solutions;

namespace BirthdayGreetingsKata.Tests.Solutions
{
    public class InMemoryGreetingsNotification : IGreetingsNotification
    {
        public List<EmailInfo> Emails { get; }

        public InMemoryGreetingsNotification()
        {
            Emails = new List<EmailInfo>();
        }

        public void Dispose()
        {
        }

        public Task SendBirthday(IList<EmailInfo> infos)
        {
            Emails.AddRange(infos);
            return Task.CompletedTask;
        }
    }
}