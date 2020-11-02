using System;

namespace BirthdayGreetingsKata
{
    public class BornOn
    {
        readonly DateTime value;

        public BornOn(in DateTime value) =>
            this.value = value;

        public bool IsBirthday(DateTime today) =>
            today.Month == value.Month && today.Day == value.Day;
    }
}
