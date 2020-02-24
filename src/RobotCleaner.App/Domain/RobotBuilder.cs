using System;
using System.Collections.Generic;
using System.Linq;
using RobotCleaner.App.Domain.Commands;

namespace RobotCleaner.App.Domain
{
    public class RobotBuilder
    {
        public const int SpaceSize = 100000;
        private int _numberOfCommands;
        private Position _startingPosition = new Position(0, 0);
        private IReadOnlyCollection<ICommand> _commands
            = new List<ICommand>();

        public RobotBuilder WithNumberOfCommands(string numberOfCommandsInput)
        {
            int.TryParse(numberOfCommandsInput, out var numberOfCommands);
            _numberOfCommands = numberOfCommands;
            return this;
        }

        public RobotBuilder StartingAt(string startingAtInput)
        {
            var inputs = startingAtInput.Split(' ');
            int.TryParse(inputs[0], out var x);
            int.TryParse(inputs[1], out var y);
            _startingPosition = new Position(x, y);
            return this;
        }

        public RobotBuilder WithCommands(Func<string> getCommandInput)
        {
            _commands = Enumerable
                .Range(0, _numberOfCommands)
                .Select(x =>
                {
                    var input = getCommandInput().Split(' ');
                    var direction = input[0];
                    int.TryParse(input[1], out var steps);
                    return GetCommand(direction, steps);
                })
                .ToList();
            return this;
        }

        private static ICommand GetCommand(string direction, int steps) 
            => direction switch
            {
                Directions.East => new EastCommand(steps),
                Directions.West => new WestCommand(steps),
                Directions.North => new NorthCommand(steps),
                Directions.South => new SouthCommand(steps),
                _ => new NullCommand(steps)
            };

        public Robot Build() => new Robot(SpaceSize, _startingPosition, _commands);
    }
}