using MarsRoverKata.AspNetHost.Controllers;
using Xunit;

namespace MarsRoverKata.AspNetHost.Tests
{
    public class RoverControllerTests : IRoverService
    {
        [Fact]
        public void SendMovementRequest()
        {
            var controller = new RoverController(this);

            var result = controller.HandleMovement(
                new MovementRequest
                {
                    Commands = "FFLB"
                });

            Assert.Equal("1,1:N:O", result.Result);
        }

        public MovementResult Handle(MovementRequest request) =>
            new MovementResult
            {
                Result = "1,1:N:O"
            };
    }
}
