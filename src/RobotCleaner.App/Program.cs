using System;
using System.Linq;
using RobotCleaner.App.Domain;

namespace RobotCleaner.App
{
    public class Program
    {
        private const int SpaceSize = 100000;

        public static void Main(string[] args)
        {
            var numberOfCommands = int.Parse(Console.ReadLine());

            var startingPositionInput = Console.ReadLine().Split(' ');
            var startingPosition = (int.Parse(startingPositionInput[0]),
                int.Parse(startingPositionInput[1]));

            var commands = Enumerable
                .Range(0, numberOfCommands)
                .Select(x =>
                {
                    var commandInput = Console.ReadLine().Split(' ');
                    return (commandInput[0], int.Parse(commandInput[1]));
                });

            var cleanedSpaces = new Robot(SpaceSize, startingPosition, commands)
                .Clean()
                .Count();
            
            Console.WriteLine($"Cleaned: {cleanedSpaces}");
        }
    }
}