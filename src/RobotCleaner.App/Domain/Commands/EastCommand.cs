using System;

namespace RobotCleaner.App.Domain.Commands
{
    public class EastCommand : UnidirectionalCommand
    {
        public EastCommand(Position startingPosition, int positionLimit)
            : base(startingPosition, positionLimit)
        {
        }

        protected override int MaxRange => PositionLimit - StartX;

        protected override Func<int, Position> CreatePosition()
            => x => new Position(StartX + x, StartY);
    }
}