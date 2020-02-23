using System;

namespace RobotCleaner.App.Domain.Commands
{
    public class WestCommand : UnidirectionalCommand
    {
        public WestCommand((int x, int y) startingPosition, int positionLimit)
            : base(startingPosition, positionLimit)
        {
        }

        protected override int MaxRange => PositionLimit + StartX;

        protected override Func<int, (int x, int y)> CreatePosition()
            => x => (StartX - x, StartY);
    }
}