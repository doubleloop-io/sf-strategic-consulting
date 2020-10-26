using System;

namespace MarsRoverKata
{
    public class Position
    {
        public  static  readonly Position MissingBegin = new Position(0,0);

        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position IncrementY() =>
            new Position(X,  Y + 1);

        public Position IncrementX() =>
            new Position(X + 1,  Y);

        public Position DecrementY() =>
            new Position(X,  Y - 1);

        public Position DecrementX() =>
            new Position(X - 1,  Y);

        public override string ToString() =>
            $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";

        protected bool Equals(Position other) => X == other.X && Y == other.Y;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position) obj);
        }

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static bool operator ==(Position left, Position right) => Equals(left, right);

        public static bool operator !=(Position left, Position right) => !Equals(left, right);
    }
}
