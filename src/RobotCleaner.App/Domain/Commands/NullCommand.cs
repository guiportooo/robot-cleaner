using System;

namespace RobotCleaner.App.Domain.Commands
{
    public class NullCommand : Command
    {
        public NullCommand(int steps) : base(steps)
        {
        }

        protected override int MaxRange => 0;
        protected override Func<int, Position> CreatePosition()
            => x => new Position(StartX, StartY);
    }
}