namespace MarsRoverKata
{
    public class Obstacle
    {
        readonly Position position;

        public Obstacle(Position position)
        {
            this.position = position;
        }

        public bool MatchPosition(Position position) =>
            this.position == position;
    }
}
