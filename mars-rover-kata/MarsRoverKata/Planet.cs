namespace MarsRoverKata
{
    public class Planet
    {
        readonly Size size;
        readonly Obstacles obstacles;

        public Planet(Size size, Obstacles obstacles)
        {
            this.size = size;
            this.obstacles = obstacles;
        }

        public Position Wrap(Position position) =>
            size.Wrap(position);

        public bool IsThereAnObstacle(Position candidate) =>
            obstacles.OnPosition(candidate);
    }
}
