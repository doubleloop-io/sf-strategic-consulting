namespace BirthdayGreetingsKata
{
    public class EmployeeInfo
    {
        public string Name { get; }
        public string Email { get; }
        public BornOn DateOfBirth { get; }

        public EmployeeInfo(string name, string email, BornOn dateOfBirth)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
        }
    }
}
