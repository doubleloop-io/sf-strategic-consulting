namespace BirthdayGreetingsKata.Solutions
{
    public  class MalformedLineException : AppException
    {
        public MalformedLineException(string line)
            : base($"Employee file contains a malformed line: {line}")
        {
        }
    }
}
