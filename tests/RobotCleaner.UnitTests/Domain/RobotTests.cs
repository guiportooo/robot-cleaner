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
            const int spaceSize = 10;
            var startingPosition = (2, -3);
            var commands = new (string direction, int steps)[] {("Unknown", 100)};

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var expected = new List<(int x, int y)>();

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnEastDirection()
        {
            const int spaceSize = 10;
            var startingPosition = (2, -3);
            var commands = new (string direction, int steps)[] {("E", 3)};

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var expected = new List<(int x, int y)> {(2, -3), (3, -3), (4, -3), (5, -3)};

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnWestDirection()
        {
            const int spaceSize = 10;
            var startingPosition = (2, -3);
            var commands = new (string direction, int steps)[] {("W", 3)};

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var expected = new List<(int x, int y)> {(2, -3), (1, -3), (0, -3), (-1, -3)};

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnNorthDirection()
        {
            const int spaceSize = 10;
            var startingPosition = (2, -3);
            var commands = new (string direction, int steps)[] {("N", 3)};

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var expected = new List<(int x, int y)> {(2, -3), (2, -2), (2, -1), (2, 0)};

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnSouthDirection()
        {
            const int spaceSize = 10;
            var startingPosition = (2, -3);
            var commands = new (string direction, int steps)[] {("S", 3)};

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var expected = new List<(int x, int y)> {(2, -3), (2, -4), (2, -5), (2, -6)};

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanManyTimesOnASingleDirection()
        {
            const int spaceSize = 10;
            var startingPosition = (2, -3);
            var commands = new (string direction, int steps)[]
            {
                ("E", 2),
                ("E", 3),
                ("E", 1)
            };

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

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
            const int spaceSize = 10;
            var startingPosition = (2, -3);
            var commands = new (string direction, int steps)[]
            {
                ("E", 2),
                ("N", 3),
                ("W", 2),
                ("S", 1),
            };

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

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
            const int spaceSize = 10;
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

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

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
        public void ShouldNotCleanOutsideSpace()
        {
            const int spaceSize = 2;
            var startingPosition = (-2, 2);
            var commands = new (string direction, int steps)[]
            {
                ("E", 5),
                ("S", 6),
                ("W", 100),
                ("N", 100000)
            };

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var expected = new List<(int x, int y)>
            {
                (-2, 2), (-1, 2), (0, 2), (1, 2), (2, 2),
                (2, 1), (2, 0), (2, -1), (2, -2),
                (1, -2), (0, -2), (-1, -2), (-2, -2),
                (-2, -1), (-2, 0), (-2, 1)
            };

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }
    }
}