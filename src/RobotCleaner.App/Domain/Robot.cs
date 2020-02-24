using System.Collections.Generic;
using System.Linq;

namespace RobotCleaner.App.Domain
{
    public class Robot
    {
        public Robot(int spaceSize,
            (int x, int y) startingPosition,
            IEnumerable<(string direction, int steps)> commands)
        {
            _spaceSize = spaceSize;
            _position = startingPosition;
            _commands = commands;
        }

        private readonly int _spaceSize;
        private (int x, int y) _position;
        private readonly IEnumerable<(string direction, int steps)> _commands;

        public IEnumerable<(int x, int y)> Clean()
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