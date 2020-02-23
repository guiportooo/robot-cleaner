using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotCleaner.App.Domain
{
    public class Command
    {
        public static ((int x, int y), IReadOnlyCollection<(int x, int y)>) Execute((int x, int y) startingPosition,
            string direction,
            int steps,
            int positionLimit)
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

            if (createPosition == null)
                return (startingPosition, new List<(int x, int y)>());

            var maxRange = direction switch
            {
                Directions.East => positionLimit - fromX,
                Directions.West => positionLimit + fromX,
                Directions.North => positionLimit - fromY,
                Directions.South => positionLimit + fromY,
                _ => 0
            };

            var maxSteps = Math.Min(steps, maxRange);
            
            var positions = Enumerable
                .Range(0, maxSteps + 1)
                .Select(createPosition)
                .ToList();

            return (positions.Last(), positions);
        }
    }
}