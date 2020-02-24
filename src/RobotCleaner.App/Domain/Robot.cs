using System.Collections.Generic;
using System.Linq;

namespace RobotCleaner.App.Domain
{
    public class Robot
    {
        private readonly int _spaceSize;
        private Position _position;
        private readonly IEnumerable<(string direction, int steps)> _commands;

        public Robot(int spaceSize,
            Position startingPosition,
            IEnumerable<(string direction, int steps)> commands)
        {
            _spaceSize = spaceSize;
            _position = startingPosition;
            _commands = commands;
        }

        public IEnumerable<Position> Clean()
            => _commands
                .SelectMany(command =>
                {
                    var (direction, steps) = command;
                    var (lastPosition, positions) = Command.Execute(_position,
                        direction,
                        steps,
                        _spaceSize);
                    _position = lastPosition;
                    return positions;
                })
                .Distinct();
    }
}