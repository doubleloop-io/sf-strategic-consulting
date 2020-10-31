using System;
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
            for (var i = 0; i < lines.Length; i++)
            {
                if (i == 0) continue;

                var line = lines[i];
                var parts = line
                    .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();

                var dateOfBirth = DateTime.Parse(parts[2]);
                if (today.Month == dateOfBirth.Month && today.Day == dateOfBirth.Day)
                    await smtpClient.SendMailAsync(
                        smtpConfiguration.Sender,
                        parts[3],
                        "Happy birthday!",
                        $"Happy birthday, dear {parts[1]}!");
            }
        }
    }
}