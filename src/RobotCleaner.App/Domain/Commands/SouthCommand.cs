using System;

namespace RobotCleaner.App.Domain.Commands
{
    public class SouthCommand : UnidirectionalCommand
    {
        public SouthCommand((int x, int y) startingPosition, int positionLimit)
            : base(startingPosition, positionLimit)
        {
        }

        protected override int MaxRange => PositionLimit + StartY;

        protected override Func<int, (int x, int y)> CreatePosition()
            => y => (StartX, StartY - y);
    }
}