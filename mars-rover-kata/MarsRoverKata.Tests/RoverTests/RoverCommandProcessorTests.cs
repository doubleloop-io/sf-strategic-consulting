using Xunit;

namespace MarsRoverKata.Tests.RoverTests
{
    public class RoverCommandProcessorTests
    {
        [Theory]
        [InlineData("LFF","0,2:W")]
        [InlineData("LFFFLBB","9,4:S")]
        [InlineData("BBBRRFFFFFF","2,5:S:O")]
        public void ProcessCommandStream(string commands, string expected)
        {
            var rover = new Rover(
                new Planet(
                    new Size(10, 10),
                    new Obstacles(new[] {new Obstacle(new Position(2, 4)),})),
                new Position(2, 2),
                Directions.N);
            var processor = new RoverCommandProcessor(rover);

            var result = processor.ProcessAll(commands);

            Assert.Equal(expected, result);
        }
    }
}
