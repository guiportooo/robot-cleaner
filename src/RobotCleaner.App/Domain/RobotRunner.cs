using System.Linq;

namespace RobotCleaner.App.Domain
{
    public class RobotRunner
    {
        private const int SpaceSize = 100000;
        private readonly IDisplay _display;

        public RobotRunner(IDisplay display) => _display = display;

        public void Run()
        {
            var numberOfCommands = GetNumberOfCommands(_display.GetInput());
            var startingPosition = GetStartingPosition(_display.GetInput());
            var commands = Enumerable
                .Range(0, numberOfCommands)
                .Select(x => GetCommand(_display.GetInput()));

            var cleanedSpaces = new Robot(SpaceSize, startingPosition, commands)
                .Clean()
                .Count();

            _display.ShowOutput($"Cleaned: {cleanedSpaces}");
        }

        private static int GetNumberOfCommands(string numberOfCommandsInput)
        {
            int.TryParse(numberOfCommandsInput, out var numberOfCommands);
            return numberOfCommands;
        }

        private static (int x, int y) GetStartingPosition(string startingAtInput)
        {
            var inputs = startingAtInput.Split(' ');
            int.TryParse(inputs[0], out var x);
            int.TryParse(inputs[1], out var y);
            return (x, y);
        }

        private static (string, int) GetCommand(string commandInput)
        {
            var input = commandInput.Split(' ');
            var direction = input[0];
            int.TryParse(input[1], out var steps);
            return (direction, steps);
        }
    }
}