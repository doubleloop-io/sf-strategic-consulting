using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BirthdayGreetingsKata
{
    public class BirthdayController
    {
        readonly IGreetingsPort greetingsPort;

        public BirthdayController(IGreetingsPort greetingsPort)
        {
            this.greetingsPort = greetingsPort;
        }

        public async Task SendGreetings(DateTime today, List<EmployeeInfo> loadedEmployees)
        {
            var birthdays = new IsBirthdayFilter(loadedEmployees).Apply(today);

            foreach (var birthday in birthdays)
                await greetingsPort.Publish(birthday);
        }
    }
}
