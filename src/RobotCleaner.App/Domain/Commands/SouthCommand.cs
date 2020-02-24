using System;

namespace RobotCleaner.App.Domain.Commands
{
    public class SouthCommand : UnidirectionalCommand
    {
        public SouthCommand(Position startingPosition, int positionLimit)
            : base(startingPosition, positionLimit)
        {
        }

        protected override int MaxRange => PositionLimit + StartY;

        protected override Func<int, Position> CreatePosition()
            => y => new Position(StartX, StartY - y);
    }
}