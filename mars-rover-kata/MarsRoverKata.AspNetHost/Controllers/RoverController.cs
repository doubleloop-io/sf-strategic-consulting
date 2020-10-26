using Microsoft.AspNetCore.Mvc;

namespace MarsRoverKata.AspNetHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoverController : ControllerBase
    {
        readonly IRoverService service;

        public RoverController(IRoverService service) =>
            this.service = service;

        [HttpPost]
        public MovementResult HandleMovement(MovementRequest request) =>
            service.Handle(request);
    }
}
