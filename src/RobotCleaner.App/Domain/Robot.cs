using System.Collections.Generic;
using System.Linq;
using RobotCleaner.App.Domain.Commands;

namespace RobotCleaner.App.Domain
{
    public class Robot
    {
        public int SpaceSize { get; }
        public Position Position { get; private set; }
        public IReadOnlyCollection<ICommand> Commands { get; }

        public Robot(int spaceSize,
            Position startingPosition,
            IEnumerable<ICommand> commands)
        {
            SpaceSize = spaceSize;
            Position = startingPosition;
            Commands = commands.ToList();
        }

        public IEnumerable<Position> Clean()
            => Commands
                .SelectMany(command =>
                {
                    var (lastPosition, positions) = command.Execute(Position, SpaceSize);
                    Position = lastPosition;
                    return positions;
                })
                .Distinct();
    }
}