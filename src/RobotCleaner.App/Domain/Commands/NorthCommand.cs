using System;

namespace RobotCleaner.App.Domain.Commands
{
    public class NorthCommand : Command
    {
       public NorthCommand(int steps)
            : base(steps)
        {
        }

        protected override int MaxRange => PositionLimit - StartY;

        protected override Func<int, Position> CreatePosition()
            => y => new Position(StartX, StartY + y);
    }
}