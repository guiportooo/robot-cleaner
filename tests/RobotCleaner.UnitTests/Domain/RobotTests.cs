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
            var commands = new (string direction, int steps)[] {("Unknown", 100)};

            var cleanedSpaces = Robot.Clean(startingPosition, commands);

            var expected = new List<(int x, int y)>();

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnEastDirection()
        {
            var startingPosition = (2, -3);
            var commands = new (string direction, int steps)[] {("E", 3)};

            var cleanedSpaces = Robot.Clean(startingPosition, commands);

            var expected = new List<(int x, int y)> {(2, -3), (3, -3), (4, -3), (5, -3)};

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnWestDirection()
        {
            var startingPosition = (2, -3);
            var commands = new (string direction, int steps)[] {("W", 3)};

            var cleanedSpaces = Robot.Clean(startingPosition, commands);

            var expected = new List<(int x, int y)> {(2, -3), (1, -3), (0, -3), (-1, -3)};

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnNorthDirection()
        {
            var startingPosition = (2, -3);
            var commands = new (string direction, int steps)[] {("N", 3)};

            var cleanedSpaces = Robot.Clean(startingPosition, commands);

            var expected = new List<(int x, int y)> {(2, -3), (2, -2), (2, -1), (2, 0)};

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnSouthDirection()
        {
            var startingPosition = (2, -3);
            var commands = new (string direction, int steps)[] {("S", 3)};

            var cleanedSpaces = Robot.Clean(startingPosition, commands);

            var expected = new List<(int x, int y)> {(2, -3), (2, -4), (2, -5), (2, -6)};

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanManyTimesOnASingleDirection()
        {
            var startingPosition = (2, -3);
            var commands = new (string direction, int steps)[]
            {
                ("E", 2),
                ("E", 3),
                ("E", 1)
            };

            var cleanedSpaces = Robot.Clean(startingPosition, commands);

            var expected = new List<(int x, int y)>
            {
                (2, -3), (3, -3), (4, -3),
                (5, -3), (6, -3), (7, -3),
                (8, -3)
            };

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanManyTimesOnManyDirections()
        {
            var startingPosition = (2, -3);
            var commands = new (string direction, int steps)[]
            {
                ("E", 2),
                ("N", 3),
                ("W", 2),
                ("S", 1),
            };

            var cleanedSpaces = Robot.Clean(startingPosition, commands);

            var expected = new List<(int x, int y)>
            {
                (2, -3), (3, -3), (4, -3),
                (4, -2), (4, -1), (4, 0),
                (3, 0), (2, 0),
                (2, -1)
            };

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanUniqueSpaces()
        {
             var startingPosition = (2, -3);
             var normalCommands = new (string direction, int steps)[]
             {
                 ("E", 2),
                 ("N", 3),
                 ("W", 2),
                 ("S", 1)
             };

             var reversedCommands = new (string direction, int steps)[]
             {
                 ("N", 1),
                 ("E", 2),
                 ("S", 3),
                 ("W", 2)
             };

             var commands = normalCommands.Concat(reversedCommands);
 
             var cleanedSpaces = Robot.Clean(startingPosition, commands);
 
             var expected = new List<(int x, int y)>
             {
                 (2, -3), (3, -3), (4, -3),
                 (4, -2), (4, -1), (4, 0),
                 (3, 0), (2, 0),
                 (2, -1)
             };
 
             cleanedSpaces.Should().BeEquivalentTo(expected);           
        }
    }
}