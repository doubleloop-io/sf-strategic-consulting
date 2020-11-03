namespace MarsRoverKata
{
    public interface IRoverService
    {
        OperationResult<MovementResult> Handle(MovementRequest req);
    }

    public class RoverService : IRoverService
    {
        public MovementResult Handle(MovementRequest req)
        {
            var rover = new Rover(
                new Planet(
                    new Size(10, 10),
                    new Obstacles(new[] {new Obstacle(new Position(2, 4)),})),
                new Position(2, 2),
                Directions.N);

            var processor = new RoverCommandProcessor(rover);

            var result = processor.ProcessAll(req.Commands);

            return new MovementResult
            {
                Result = result
            };
        }
    }

    /*
     *  JSON => MovementRequest(String, int, double, float, bool, datetime, array)
     *  JSON-API => MovementRequest
     *  GraphAPI-API => MovementRequest
     *  CustomProtocol => MovementRequest
     *
     *
     * DomainException => HTTP Status
     * ValidationEx => 400
     * NotFoundEx => 404
     */

    public class MovementRequest
    {
        public string Commands { get; set; }
    }

    public class MovementResult
    {
        public string Result { get; set; }
    }
}
