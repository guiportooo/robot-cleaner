using System.Collections.Generic;
using System.Linq;

namespace RobotCleaner.App.Domain
{
    public readonly struct CommandResult
    {
        public (int x, int y) LastPosition { get; }
        public IReadOnlyCollection<(int x, int y)> Positions { get; }

        public CommandResult((int x, int y) lastPosition, 
            IEnumerable<(int x, int y)> positions)
        {
            LastPosition = lastPosition;
            Positions = positions.ToList();
        }

        public void Deconstruct(out (int x, int y) lastPosition,
            out IReadOnlyCollection<(int x, int y)> positions)
        {
            lastPosition = LastPosition;
            positions = Positions;
        }
    }
}