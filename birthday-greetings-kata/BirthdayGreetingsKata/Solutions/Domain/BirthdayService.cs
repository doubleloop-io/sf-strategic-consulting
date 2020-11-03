using System;
using System.Threading.Tasks;

namespace BirthdayGreetingsKata.Solutions
{
    public class BirthdayService
    {
        readonly IEmployeeCatalog employeeCatalog;
        readonly IGreetingsNotification greetingsNotification;

        public BirthdayService(IEmployeeCatalog employeeCatalog, IGreetingsNotification greetingsNotification)
        {
            this.employeeCatalog = employeeCatalog;
            this.greetingsNotification = greetingsNotification;
        }

        public async Task SendGreetings(DateTime today)
        {
            var allEmployees = await employeeCatalog.Load();

            var birthdayEmployees =
                new BirthdayFilter(allEmployees)
                    .Apply(today);

            await greetingsNotification.SendBirthday(birthdayEmployees);
        }
    }
}