using Xunit;

namespace MarsRoverKata.Tests.RoverTests
{
    public class LeftRotationTests
    {
        [Fact]
        public void RotateOnLeft()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                Position.MissingBegin,
                Directions.N);

            rover.RotateLeft();

            Assert.Equal(Directions.W, rover.Direction);
        }
        
        [Fact]
        public void RotateTwoTimesOnLeft()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                Position.MissingBegin,
                Directions.N);

            rover.RotateLeft();
            rover.RotateLeft();

            Assert.Equal(Directions.S, rover.Direction);
        }
        
        [Fact]
        public void RotateTwoThreeOnLeft()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                Position.MissingBegin,
                Directions.N);

            rover.RotateLeft();
            rover.RotateLeft();
            rover.RotateLeft();

            Assert.Equal(Directions.E, rover.Direction);
        }

        [Fact]
        public void RotateFourTimesOnLeft()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                Position.MissingBegin,
                Directions.N);

            rover.RotateLeft();
            rover.RotateLeft();
            rover.RotateLeft();
            rover.RotateLeft();

            Assert.Equal(Directions.N, rover.Direction);
        }

        [Fact]
        public void RotateComeBackOnLeft()
        {
            var rover = new Rover(
                new Planet(new Size(10, 10), Obstacles.Empty),
                Position.MissingBegin,
                Directions.N);

            rover.RotateLeft();
            rover.RotateRight();

            Assert.Equal(Directions.N, rover.Direction);
        }
    }
}
