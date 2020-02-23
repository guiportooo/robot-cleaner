using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using RobotCleaner.App.Domain;

namespace RobotCleaner.UnitTests.Domain
{
    public class RobotTests
    {
        [Test]
        public void ShouldNotCleanIfDirectionIsUnknown()
        {
            var startingPosition = (2, -3);
            const string direction = "Unknown";
            const int steps = 100;

            var cleanedSpaces = Robot.Clean(startingPosition, direction, steps);

            var expected = new List<(int x, int y)>();

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnEastDirection()
        {
            var startingPosition = (2, -3);
            const string direction = "E";
            const int steps = 3;

            var cleanedSpaces = Robot.Clean(startingPosition, direction, steps);

            var expected = new List<(int x, int y)> {(2, -3), (3, -3), (4, -3), (5, -3)};

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnWestDirection()
        {
            var startingPosition = (2, -3);
            const string direction = "W";
            const int steps = 3;

            var cleanedSpaces = Robot.Clean(startingPosition, direction, steps);

            var expected = new List<(int x, int y)> {(2, -3), (1, -3), (0, -3), (-1, -3)};

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnNorthDirection()
        {
            var startingPosition = (2, -3);
            const string direction = "N";
            const int steps = 3;

            var cleanedSpaces = Robot.Clean(startingPosition, direction, steps);

            var expected = new List<(int x, int y)> {(2, -3), (2, -2), (2, -1), (2, 0)};

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }
        
        [Test]
        public void ShouldCleanOnSouthDirection()
        {
            var startingPosition = (2, -3);
            const string direction = "S";
            const int steps = 3;

            var cleanedSpaces = Robot.Clean(startingPosition, direction, steps);

            var expected = new List<(int x, int y)> {(2, -3), (2, -4), (2, -5), (2, -6)};

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }
    }
}