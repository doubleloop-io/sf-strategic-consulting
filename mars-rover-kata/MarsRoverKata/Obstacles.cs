using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata
{
    public class Obstacles
    {
        public static readonly  Obstacles Empty = new Obstacles(new List<Obstacle>());

        readonly IEnumerable<Obstacle> items;

        public Obstacles(IEnumerable<Obstacle> items) =>
            this.items = items;

        public bool OnPosition(Position position) =>
            items.Any(x => x.MatchPosition(position));
    }
}
