using System.Threading.Tasks;

namespace BirthdayGreetingsKata
{
    public interface IGreetingsPort
    {
        Task Publish(EmployeeInfo birthday);
    }
}
