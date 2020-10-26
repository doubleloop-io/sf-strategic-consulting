using Xunit;

namespace MarsRoverKata.Tests.RoverTests
{
    public class HitObstacleTests
    {
        [Fact]
        public void MoveForwardUntilObstacle()
        {
            var rover = new Rover(
                new Planet(
                    new Size(10, 10),
                    new Obstacles(new[] {new Obstacle(new Position(2, 4)),})),
                new Position(2, 2),
                Directions.N);

            rover.MoveForward();

            Assert.Throws<ObstacleOnNextPositionException>(
                () => rover.MoveForward());
            Assert.Equal(new Position(2, 3), rover.Position);
        }

        [Fact]
        public void MoveBackwardUntilObstacle()
        {
            var rover = new Rover(
                new Planet(
                    new Size(10, 10),
                    new Obstacles(new[] {new Obstacle(new Position(2, 0)),})),
                new Position(2, 2),
                Directions.N);

            rover.MoveBackward();

            Assert.Throws<ObstacleOnNextPositionException>(
                () => rover.MoveBackward());
            Assert.Equal(new Position(2, 1), rover.Position);
        }
    }
}
