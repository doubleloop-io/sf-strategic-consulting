using Xunit;

namespace MarsRoverKata.Tests
{
    public class RoverServiceTests
    {
        [Fact]
        public void HandleMovementRequest()
        {
            var service = new RoverService();
            var result = service.Handle(
                new MovementRequest
                {
                    Commands = "FFLB"
                });
            Assert.Equal("1,0:N", result.Result);
        }
    }
}
