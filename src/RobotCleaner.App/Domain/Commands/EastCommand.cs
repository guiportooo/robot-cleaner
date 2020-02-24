using System;

namespace RobotCleaner.App.Domain.Commands
{
    public class EastCommand : Command
    {
        public EastCommand(int steps)
            : base(steps)
        {
        }

        protected override int MaxRange => PositionLimit - StartX;

        protected override Func<int, Position> CreatePosition()
            => x => new Position(StartX + x, StartY);
    }
}