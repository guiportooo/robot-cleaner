using System;
using RobotCleaner.App.Domain;

namespace RobotCleaner.App
{
    public class ConsoleDisplay : IDisplay
    {
        public string GetInput() => Console.ReadLine();

        public void ShowOutput(string output) => Console.WriteLine(output);
    }
}