using Xunit;

namespace MarsRoverKata.Tests.RoverTests
{
    public class MoveForwardTests
    {
        [Fact]
        public void MoveUp()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                new Position(2, 2),
                Directions.N);

            rover.MoveForward();
            rover.MoveForward();

            Assert.Equal(new Position(2, 4), rover.Position);
        }

        [Fact]
        public void MoveRight()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                new Position(2, 2),
                Directions.E);

            rover.MoveForward();
            rover.MoveForward();

            Assert.Equal(new Position(4, 2), rover.Position);
        }

        [Fact]
        public void MoveLeft()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                new Position(2, 2),
                Directions.W);

            rover.MoveForward();
            rover.MoveForward();

            Assert.Equal(new Position(0, 2), rover.Position);
        }

        [Fact]
        public void MoveDown()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                new Position(2, 2),
                Directions.S);

            rover.MoveForward();
            rover.MoveForward();

            Assert.Equal(new Position(2, 0), rover.Position);
        }
    }
}
