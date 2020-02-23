using System.Collections.Generic;
using RobotCleaner.App.Domain.Commands;

namespace RobotCleaner.App.Domain
{
    public class Command
    {
        public static ((int x, int y), IReadOnlyCollection<(int x, int y)>) Execute((int x, int y) startingPosition,
            string direction,
            int steps,
            int positionLimit) 
            => (direction switch
            {
                Directions.East => (UnidirectionalCommand) new EastCommand(startingPosition, positionLimit),
                Directions.West => new WestCommand(startingPosition, positionLimit),
                Directions.North => new NorthCommand(startingPosition, positionLimit),
                Directions.South => new SouthCommand(startingPosition, positionLimit),
                _ => null
            })?.Execute(steps) ?? (startingPosition, new List<(int x, int y)>());
    }
}