using System;
using System.Linq;
using netDumbster.smtp;

namespace BirthdayGreetingsKata.Tests.Support
{
    public class ReceivedMail
    {
        public string FromAddress { get; }
        public string ToAddress { get; }
        public string Subject { get; }
        public string Body { get; }

        public ReceivedMail(string fromAddress, string toAddress, string subject, string body)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
            Subject = subject;
            Body = body;
        }

        public override string ToString() =>
            $"{nameof(FromAddress)}: {FromAddress}, {nameof(ToAddress)}: {ToAddress}, {nameof(Subject)}: {Subject}, {nameof(Body)}: {Body}";

        protected bool Equals(ReceivedMail other) =>
            FromAddress == other.FromAddress && ToAddress == other.ToAddress && Subject == other.Subject && Body == other.Body;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ReceivedMail) obj);
        }

        public override int GetHashCode() => HashCode.Combine(FromAddress, ToAddress, Subject, Body);

        public static bool operator ==(ReceivedMail left, ReceivedMail right) => Equals(left, right);

        public static bool operator !=(ReceivedMail left, ReceivedMail right) => !Equals(left, right);

        static ReceivedMail From(SmtpMessage smtpMessage)
        {
            var fromAddress = smtpMessage.FromAddress.Address;
            var toAddress = smtpMessage.ToAddresses.Single().Address;
            var subject = smtpMessage.Headers["Subject"];
            var messagePart = smtpMessage.MessageParts.Single();
            var body = messagePart.BodyData;
            return new ReceivedMail(fromAddress, toAddress, subject, body);
        }

        public static ReceivedMail[] FromAll(SimpleSmtpServer smtpServer) =>
            smtpServer.ReceivedEmail
                .Select(From)
                .OrderBy(x => x.ToAddress)
                .ToArray();
    }
}
