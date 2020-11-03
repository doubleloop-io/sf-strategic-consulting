using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayGreetingsKata.Solutions;

namespace BirthdayGreetingsKata.Tests.Solutions
{
    // Test Double - Fake
    // Adapter in memory
    public class InMemoryEmployeeCatalog : IEmployeeCatalog
    {
        readonly IList<Employee> employees;

        public InMemoryEmployeeCatalog(params Employee[] employees) =>
            this.employees = (employees ?? new Employee[0]).ToList();

        public Task<IList<Employee>> Load() => Task.FromResult(employees);
    }
}
