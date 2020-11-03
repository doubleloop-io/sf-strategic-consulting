using System.Collections.Generic;
using System.Threading.Tasks;
using BirthdayGreetingsKata.Solutions;

namespace BirthdayGreetingsKata.Tests.Solutions
{
    public class InMemoryGreetingsNotification : IGreetingsNotification
    {
        public List<EmailInfo> ReceivedEmails { get; }

        public InMemoryGreetingsNotification()
        {
            ReceivedEmails = new List<EmailInfo>();
        }

        public void Dispose()
        {
        }

        public Task SendBirthday(IList<EmailInfo> infos)
        {
            ReceivedEmails.AddRange(infos);
            return Task.CompletedTask;
        }
    }
}
