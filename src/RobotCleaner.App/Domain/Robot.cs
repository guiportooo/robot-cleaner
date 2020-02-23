using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotCleaner.App.Domain
{
    public class Robot
    {
        public static IEnumerable<(int x, int y)> Clean((int, int) startingPosition,
            string direction,
            int steps)
        {
            var (fromX, fromY) = startingPosition;

            Func<int, (int x, int y)> createPosition = direction switch
            {
                Directions.East => x => (fromX + x, fromY),
                Directions.West => x => (fromX - x, fromY),
                Directions.North => y => (fromX, fromY + y),
                Directions.South => y => (fromX, fromY - y),
                _ => null
            };

            if (createPosition != null)
                return Enumerable
                    .Range(0, steps + 1)
                    .Select(createPosition);

            return new List<(int x, int y)>();
        }
    }
}