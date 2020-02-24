using System;

namespace RobotCleaner.App.Domain.Commands
{
    public class WestCommand : Command
    {
        public WestCommand(int steps)
            : base(steps)
        {
        }

        protected override int MaxRange => PositionLimit + StartX;

        protected override Func<int, Position> CreatePosition()
            => x => new Position(StartX - x, StartY);
    }
}