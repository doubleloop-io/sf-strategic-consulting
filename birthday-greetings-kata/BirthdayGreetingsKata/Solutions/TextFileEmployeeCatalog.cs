using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BirthdayGreetingsKata.Solutions
{
    public class TextFileEmployeeCatalog : IEmployeeCatalog
    {
        readonly FileConfiguration configuration;

        public TextFileEmployeeCatalog(FileConfiguration configuration) =>
            this.configuration = configuration;

        public async Task<IList<Employee>> Load()
        {
            var lines = await LoadLinesOrDefault();
            return EmployeeFileParser.ParseLines(lines);
        }

        async Task<string[]> LoadLinesOrDefault()
        {
            try
            {
                return await File.ReadAllLinesAsync(configuration.FilePath);
            }
            catch (FileNotFoundException)
            {
                return new string[0];
            }
        }
    }
}
