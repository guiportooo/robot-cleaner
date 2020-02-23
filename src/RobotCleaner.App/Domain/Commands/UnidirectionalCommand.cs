using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotCleaner.App.Domain.Commands
{
    public abstract class UnidirectionalCommand
    {
        protected UnidirectionalCommand((int x, int y) startingPosition, int positionLimit)
        {
            (StartX, StartY) = startingPosition;
            PositionLimit = positionLimit;
        }

        protected readonly int StartX;
        protected readonly int StartY;
        protected readonly int PositionLimit;
        protected abstract int MaxRange { get; }

        protected abstract Func<int, (int x, int y)> CreatePosition();

        public ((int x, int y), IReadOnlyCollection<(int x, int y)>) Execute(int steps)
        {
            var positions = Enumerable
                .Range(0, CalculateSteps(steps))
                .Select(CreatePosition())
                .ToList();

            return (positions.Last(), positions);
        }

        private int CalculateSteps(int steps) => Math.Min(steps, MaxRange) + 1;
    }
}