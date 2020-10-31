using System;

namespace BirthdayGreetingsKata.Solutions
{
    public class Employee
    {
        public Employee(DateOfBirth dateOfBirth, EmailInfo emailInfo)
        {
            DateOfBirth = dateOfBirth;
            EmailInfo = emailInfo;
        }

        public DateOfBirth DateOfBirth { get; }
        public EmailInfo EmailInfo { get; }

        public override string ToString() => $"{nameof(DateOfBirth)}: {DateOfBirth}, {nameof(EmailInfo)}: {EmailInfo}";

        protected bool Equals(Employee other) => Equals(DateOfBirth, other.DateOfBirth) && Equals(EmailInfo, other.EmailInfo);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Employee) obj);
        }

        public override int GetHashCode() => HashCode.Combine(DateOfBirth, EmailInfo);

        public static bool operator ==(Employee left, Employee right) => Equals(left, right);

        public static bool operator !=(Employee left, Employee right) => !Equals(left, right);
    }
}
