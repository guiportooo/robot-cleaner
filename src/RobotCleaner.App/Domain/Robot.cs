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
            switch (direction)
            {
                case "E":
                {
                    var (from, y) = startingPosition;
                    return Enumerable
                        .Range(0, steps + 1)
                        .Select(x => (from + x, y));
                }
                case "W":
                {
                    var (from, y) = startingPosition;
                    return Enumerable
                        .Range(0, steps + 1)
                        .Select(x => (from - x, y));
                }
                case "N":
                {
                    var (x, from) = startingPosition;
                    return Enumerable
                        .Range(0, steps + 1)
                        .Select(y => (x, from + y));
                }
                case "S":
                {
                    var (x, from) = startingPosition;
                    return Enumerable
                        .Range(0, steps + 1)
                        .Select(y => (x, from - y));
                }
            }

            return new List<(int x, int y)>();
        }
    }
}