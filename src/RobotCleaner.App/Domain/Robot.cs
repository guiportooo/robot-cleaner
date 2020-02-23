using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotCleaner.App.Domain
{
    public class Robot
    {
        public static IEnumerable<(int x, int y)> Clean(int spaceSize,
            (int, int) startingPosition,
            IEnumerable<(string direction, int steps)> commands)
        {
            var position = startingPosition;

            return commands
                .SelectMany(command =>
                {
                    var (direction, steps) = command;
                    var (lastPosition, positions) = Command.Execute(position,
                        direction,
                        steps,
                        spaceSize);
                    position = lastPosition;
                    return positions;
                })
                .Distinct();
        }
    }
}