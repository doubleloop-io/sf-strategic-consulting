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

        // TextFile -> Employees
        public async Task<IList<Employee>> Load()
        {
            var lines = await LoadLinesOrDefault();
            return TextFileToEmployeeParser.ParseLines(lines);
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

    public class MongoDbCatalog : IEmployeeCatalog
    {
        // BsonDocuments -> Employees
        public Task<IList<Employee>> Load() => throw new System.NotImplementedException();
    }
}
