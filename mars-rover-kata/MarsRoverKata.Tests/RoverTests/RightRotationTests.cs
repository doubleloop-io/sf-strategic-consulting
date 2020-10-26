using Xunit;

namespace MarsRoverKata.Tests.RoverTests
{
    public class RightRotationTests
    {
        [Fact]
        public void RotateOnRight()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                Position.MissingBegin,
                Directions.N);

            rover.RotateRight();

            Assert.Equal(Directions.E, rover.Direction);
        }

        [Fact]
        public void RotateTwoTimesOnRight()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                Position.MissingBegin,
                Directions.N);

            rover.RotateRight();
            rover.RotateRight();

            Assert.Equal(Directions.S, rover.Direction);
        }

        [Fact]
        public void RotateTwoThreeOnRight()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                Position.MissingBegin,
                Directions.N);

            rover.RotateRight();
            rover.RotateRight();
            rover.RotateRight();

            Assert.Equal(Directions.W, rover.Direction);
        }

        [Fact]
        public void RotateFourTimesOnRight()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                Position.MissingBegin,
                Directions.N);

            rover.RotateRight();
            rover.RotateRight();
            rover.RotateRight();
            rover.RotateRight();

            Assert.Equal(Directions.N, rover.Direction);
        }

        [Fact]
        public void RotateComeBackOnRight()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                Position.MissingBegin,
                Directions.N);

            rover.RotateRight();
            rover.RotateLeft();

            Assert.Equal(Directions.N, rover.Direction);
        }
    }
}
