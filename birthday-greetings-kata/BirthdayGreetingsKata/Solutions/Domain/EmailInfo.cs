using System;

namespace BirthdayGreetingsKata.Solutions
{
    public class EmailInfo
    {
        public EmailInfo(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; }
        public string Email { get; }

        public override string ToString() =>
            $"{nameof(Name)}: {Name}, {nameof(Email)}: {Email}";

        protected bool Equals(EmailInfo other) => string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) &&
                                                  string.Equals(Email, other.Email, StringComparison.InvariantCultureIgnoreCase);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((EmailInfo) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(Email, StringComparer.InvariantCultureIgnoreCase);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(EmailInfo left, EmailInfo right) => Equals(left, right);

        public static bool operator !=(EmailInfo left, EmailInfo right) => !Equals(left, right);
    }
}