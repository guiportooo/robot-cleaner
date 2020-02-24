using System.Collections.Generic;
using System.Linq;

namespace RobotCleaner.App.Domain
{
    public readonly struct CommandResult
    {
        public Position LastPosition { get; }
        public IReadOnlyCollection<Position> Positions { get; }

        public CommandResult(Position lastPosition, 
            IEnumerable<Position> positions)
        {
            LastPosition = lastPosition;
            Positions = positions.ToList();
        }

        public void Deconstruct(out Position lastPosition,
            out IReadOnlyCollection<Position> positions)
        {
            lastPosition = LastPosition;
            positions = Positions;
        }
    }
}