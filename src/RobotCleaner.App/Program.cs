using RobotCleaner.App.Domain;

namespace RobotCleaner.App
{
    public class Program
    {
        public static void Main(string[] args) 
            => new RobotRunner(new ConsoleDisplay()).Run();
    }
}