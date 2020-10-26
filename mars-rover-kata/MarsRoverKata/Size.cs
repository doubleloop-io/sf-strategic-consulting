namespace MarsRoverKata
{
    public class Size
    {
        readonly int height;
        readonly int width;

        public Size(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public Position Wrap(Position position) =>
            new Position(
                Wrap(width, position.X),
                Wrap(height, position.Y)
            );

        static  int Wrap(int max, int value)=>
            value >= 0 ? value % max : max + value;
    }
}
