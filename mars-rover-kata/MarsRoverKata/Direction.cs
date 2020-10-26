namespace MarsRoverKata
{
    public interface IDirection
    {
        IDirection OnLeft();
        IDirection OnRight();
        Position MoveForward(Position position);
        Position MoveBackward(Position position);
    }

    public static class Directions
    {
        public  static  readonly IDirection N = new North();
        public  static  readonly IDirection E = new East();
        public  static  readonly IDirection W = new West();
        public  static  readonly IDirection S = new South();
    }

    public class North : IDirection
    {
        public IDirection OnLeft() => Directions.W;

        public IDirection OnRight() => Directions.E;

        public Position MoveForward(Position position) =>
            position.IncrementY();

        public Position MoveBackward(Position position) =>
            position.DecrementY();

        public override string ToString() => "N";
    }

    public class East : IDirection
    {
        public IDirection OnLeft() => Directions.N;

        public IDirection OnRight() => Directions.S;

        public Position MoveForward(Position position) =>
            position.IncrementX();

        public Position MoveBackward(Position position) =>
            position.DecrementX();

        public override string ToString() => "E";
    }

    public class West : IDirection
    {
        public IDirection OnLeft() => Directions.S;

        public IDirection OnRight() => Directions.N;

        public Position MoveForward(Position position) =>
            position.DecrementX();

        public Position MoveBackward(Position position) =>
            position.IncrementX();

        public override string ToString() => "W";
    }

    public class South : IDirection
    {
        public IDirection OnLeft() => Directions.E;

        public IDirection OnRight() => Directions.W;

        public Position MoveForward(Position position) =>
            position.DecrementY();

        public Position MoveBackward(Position position) =>
            position.IncrementY();

        public override string ToString() => "S";
    }
}
