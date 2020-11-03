using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BirthdayGreetingsKata
{
    public class GreetingsApp
    {
        readonly FileConfiguration fileConfiguration;
        readonly SmtpConfiguration smtpConfiguration;

        public GreetingsApp(FileConfiguration fileConfiguration, SmtpConfiguration smtpConfiguration)
        {
            this.fileConfiguration = fileConfiguration;
            this.smtpConfiguration = smtpConfiguration;
        }

        public async Task Run(DateTime today)
        {
            using var smtpClient = new SmtpClient(smtpConfiguration.Host, smtpConfiguration.Port);
            var lines = await File.ReadAllLinesAsync(fileConfiguration.FilePath);
            var loadedEmployees = new List<EmployeeInfo>();
            for (var i = 0; i < lines.Length; i++)
            {
                if (i == 0) continue;

                var line = lines[i];
                var parts = line
                    .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();

                var employee = new EmployeeInfo(parts[1], parts[3], new BornOn(DateTime.Parse(parts[2])));
                loadedEmployees.Add(employee);
            }

            var controller = new BirthdayController(new SmtpGreetingsAdapter(smtpConfiguration, smtpClient));
            await controller.SendGreetings(today, loadedEmployees);
        }
    }
}
