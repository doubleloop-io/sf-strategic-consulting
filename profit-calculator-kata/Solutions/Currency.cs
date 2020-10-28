namespace ProfitCalculatorKata.Solutions
{
    public class Currency
    {
        readonly string value;

        public Currency(string value)
        {
            this.value = value;
        }

        public override string ToString() => $"{nameof(value)}: {value}";

        protected bool Equals(Currency other) => value == other.value;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Currency) obj);
        }

        public override int GetHashCode() => (value != null ? value.GetHashCode() : 0);

        public static bool operator ==(Currency left, Currency right) => Equals(left, right);

        public static bool operator !=(Currency left, Currency right) => !Equals(left, right);
    }
}
