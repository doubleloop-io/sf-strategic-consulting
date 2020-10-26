using System;

namespace MarsRoverKata
{
    public class RoverCommandProcessor
    {
        readonly Rover rover;

        public RoverCommandProcessor(Rover rover) =>
            this.rover = rover;

        public string ProcessAll(string commands)
        {
            var obstacleHit = false;
            foreach (var command in commands)
            {
                try
                {
                    ProcessOne(command);
                }
                catch (ObstacleOnNextPositionException)
                {
                    obstacleHit = true;
                    break;
                }
            }
            var obstaclePart = obstacleHit ? ":O" : "";
            return $"{rover.Position.X},{rover.Position.Y}:{rover.Direction}{obstaclePart}";
        }

        void ProcessOne(char command)
        {
            switch (command)
            {
                case 'F':
                    rover.MoveForward();
                    break;
                case 'B':
                    rover.MoveBackward();
                    break;
                case 'L':
                    rover.RotateLeft();
                    break;
                case 'R':
                    rover.RotateRight();
                    break;
                default:
                    throw new InvalidOperationException($"Unknown command: {command}");
            }
        }
    }
}
