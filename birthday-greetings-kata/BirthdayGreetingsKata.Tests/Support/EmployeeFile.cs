namespace BirthdayGreetingsKata.Tests.Support
{
    public static class EmployeeFile
    {
        public static void File(string fileName, params string[] lines) =>
            System.IO.File.WriteAllLines(fileName, lines);

        public static string Employee(string name, string date, string email) =>
            $"Ann, {name}, {date}, {email}";

        public static string Header() =>
            "last_name, first_name, date_of_birth, email";

        public static void DeleteFile(string fileName) =>
            System.IO.File.Delete(fileName);

        public static string MissingName(string date, string email) =>
            $"Ann,, {date}, {email}";

        public static string WrongSeparator(string name, string date, string email) =>
            $"Ann; {name}; {date}; {email}";
    }
}