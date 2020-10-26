using Xunit;

namespace MarsRoverKata.Tests.RoverTests
{
    public class WrapPlanetTests
    {
        [Fact]
        public void OverUp()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                new Position(0, 9),
                Directions.N);

            rover.MoveForward();

            Assert.Equal(new Position(0, 0), rover.Position);
        }

        [Fact]
        public void OverDown()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                new Position(0, 0),
                Directions.N);

            rover.MoveBackward();

            Assert.Equal(new Position(0, 9), rover.Position);
        }

        [Fact]
        public void OverRight()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                new Position(9, 0),
                Directions.E);

            rover.MoveForward();

            Assert.Equal(new Position(0, 0), rover.Position);
        }

        [Fact]
        public void OverLeft()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                new Position(0, 0),
                Directions.E);

            rover.MoveBackward();

            Assert.Equal(new Position(9, 0), rover.Position);
        }
    }
}
