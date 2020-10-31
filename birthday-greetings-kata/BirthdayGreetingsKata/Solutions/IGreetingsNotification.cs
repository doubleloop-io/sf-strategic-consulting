using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BirthdayGreetingsKata.Solutions
{
    public interface IGreetingsNotification : IDisposable
    {
        Task SendBirthday(IList<EmailInfo> infos);
    }
}
