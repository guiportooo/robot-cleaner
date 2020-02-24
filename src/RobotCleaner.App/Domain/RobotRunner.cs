using System.Linq;

namespace RobotCleaner.App.Domain
{
    public class RobotRunner
    {
        private readonly IDisplay _display;

        public RobotRunner(IDisplay display) => _display = display;

        public void Run() => _display.ShowOutput(
            @$"Cleaned: {new RobotBuilder()
                .WithNumberOfCommands(_display.GetInput())
                .StartingAt(_display.GetInput())
                .WithCommands(() => _display.GetInput())
                .Build()
                .Clean()
                .Count()}");
    }
}