namespace MarsRoverKata
{
    public class Rover
    {
        readonly Planet planet;
        public Position Position { get; private set; }
        public IDirection Direction { get; private set; }

        public Rover(Planet planet, Position position, IDirection direction)
        {
            this.planet = planet;
            Position = position;
            Direction = direction;
        }

        public void RotateLeft() =>
            Direction = Direction.OnLeft();

        public void RotateRight() =>
            Direction = Direction.OnRight();

        public void MoveForward() =>
            UpdatePosition(Direction.MoveForward(Position));

        public void MoveBackward()=>
            UpdatePosition(Direction.MoveBackward(Position));

        void UpdatePosition(Position candidate)
        {
            var wrapped = planet.Wrap(candidate);
            if (planet.IsThereAnObstacle(wrapped))
                throw new ObstacleOnNextPositionException();
            Position = wrapped;
        }
    }
}
