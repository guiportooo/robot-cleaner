using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotCleaner.App.Domain
{
    public class RobotBuilder
    {
        private const int SpaceSize = 100000;
        private int _numberOfCommands;
        private (int x, int y) _startingPosition;
        private IEnumerable<(string direction, int steps)> _commands 
            = new List<(string direction, int steps)>();

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
            _startingPosition = (x, y);
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
                    return (direction, steps);
                });
            return this;
        }
        
        public Robot Build() => new Robot(SpaceSize, _startingPosition, _commands); 
    }
}