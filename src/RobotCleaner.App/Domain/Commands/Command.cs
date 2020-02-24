using System;
using System.Linq;

namespace RobotCleaner.App.Domain.Commands
{
    public interface ICommand
    {
        CommandResult Execute(Position startingPosition, int positionLimit);
    }
    
    public abstract class Command : ICommand
    {
        protected Command(int steps) => Steps = steps;

        public int Steps { get; }
        protected int StartX;
        protected int StartY;
        protected int PositionLimit;
        protected abstract int MaxRange { get; }

        protected abstract Func<int, Position> CreatePosition();

        public CommandResult Execute(Position startingPosition, int positionLimit)
        {
            (StartX, StartY) = startingPosition;
            PositionLimit = positionLimit;
            
            var positions = Enumerable
                .Range(0, CalculateSteps(Steps))
                .Select(CreatePosition())
                .ToList();

            return new CommandResult(positions.Last(), positions);
        }

        private int CalculateSteps(int steps) => Math.Min(steps, MaxRange) + 1;
    }
}