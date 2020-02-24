using System;

namespace RobotCleaner.App.Domain
{
    public readonly struct Position : IEquatable<Position>
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }

        public int X { get; }
        public int Y { get; }

        public bool Equals(Position other)
            => (X, Y) == (other.X, other.Y);

        public override bool Equals(object obj)
            => obj is Position other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(X, Y);

        public static bool operator ==(Position left, Position right)
            => left.Equals(right);

        public static bool operator !=(Position left, Position right)
            => !(left == right);
    }
}