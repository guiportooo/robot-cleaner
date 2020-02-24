using System.Collections.Generic;
using RobotCleaner.App.Domain.Commands;

namespace RobotCleaner.App.Domain
{
    public static class Command
    {
        public static CommandResult Execute(Position startingPosition,
            string direction,
            int steps,
            int positionLimit)
        {
            UnidirectionalCommand command = direction switch
            {
                Directions.East => new EastCommand(startingPosition, positionLimit),
                Directions.West => new WestCommand(startingPosition, positionLimit),
                Directions.North => new NorthCommand(startingPosition, positionLimit),
                Directions.South => new SouthCommand(startingPosition, positionLimit),
                _ => null
            };

            return command?.Execute(steps)
                   ?? new CommandResult(startingPosition, new List<Position>());
        }
    }
}