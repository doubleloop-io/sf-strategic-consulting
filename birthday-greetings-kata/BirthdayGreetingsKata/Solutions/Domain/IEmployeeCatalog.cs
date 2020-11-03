using System.Collections.Generic;
using System.Threading.Tasks;

namespace BirthdayGreetingsKata.Solutions
{
    public interface IEmployeeCatalog
    {
        Task<IList<Employee>> Load();
    }
}
