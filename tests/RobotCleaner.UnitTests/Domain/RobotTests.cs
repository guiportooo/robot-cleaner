using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using RobotCleaner.App.Domain;
using RobotCleaner.App.Domain.Commands;

namespace RobotCleaner.UnitTests.Domain
{
    public class RobotTests
    {
        [Test]
        public void ShouldCleanOnlyStartingPositionCommandIsNull()
        {
            const int spaceSize = 10;
            var startingPosition = new Position(2, -3);
            var commands = new[] {new NullCommand(100)};

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var expected = new List<Position> {new Position(2, -3)};

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnEastDirection()
        {
            const int spaceSize = 10;
            var startingPosition = new Position(2, -3);
            var commands = new[] {new EastCommand(3)};

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var expected = new List<Position>
            {
                new Position(2, -3),
                new Position(3, -3),
                new Position(4, -3),
                new Position(5, -3)
            };

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnWestDirection()
        {
            const int spaceSize = 10;
            var startingPosition = new Position(2, -3);
            var commands = new[] {new WestCommand(3)};

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var expected = new List<Position>
            {
                new Position(2, -3),
                new Position(1, -3),
                new Position(0, -3),
                new Position(-1, -3)
            };

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnNorthDirection()
        {
            const int spaceSize = 10;
            var startingPosition = new Position(2, -3);
            var commands = new[] {new NorthCommand(3)};

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var expected = new List<Position>
            {
                new Position(2, -3),
                new Position(2, -2),
                new Position(2, -1),
                new Position(2, 0)
            };

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanOnSouthDirection()
        {
            const int spaceSize = 10;
            var startingPosition = new Position(2, -3);
            var commands = new[] {new SouthCommand(3)};

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var expected = new List<Position>
            {
                new Position(2, -3),
                new Position(2, -4),
                new Position(2, -5),
                new Position(2, -6)
            };

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanManyTimesOnASingleDirection()
        {
            const int spaceSize = 10;
            var startingPosition = new Position(2, -3);
            var commands = new[]
            {
                new EastCommand(2),
                new EastCommand(3),
                new EastCommand(1)
            };

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var expected = new List<Position>
            {
                new Position(2, -3), new Position(3, -3), new Position(4, -3),
                new Position(5, -3), new Position(6, -3), new Position(7, -3),
                new Position(8, -3)
            };

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanManyTimesOnManyDirections()
        {
            const int spaceSize = 10;
            var startingPosition = new Position(2, -3);
            var commands = new List<ICommand>
            {
                new EastCommand(2),
                new NorthCommand(3),
                new WestCommand(2),
                new SouthCommand(1)
            };

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var expected = new List<Position>
            {
                new Position(2, -3), new Position(3, -3), new Position(4, -3),
                new Position(4, -2), new Position(4, -1), new Position(4, 0),
                new Position(3, 0), new Position(2, 0),
                new Position(2, -1)
            };

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldCleanUniqueSpaces()
        {
            const int spaceSize = 10;
            var startingPosition = new Position(2, -3);
            var normalCommands = new List<ICommand> 
            {
                new EastCommand(2),
                new NorthCommand(3),
                new WestCommand(2),
                new SouthCommand(1)
            };

            var reversedCommands = new List<ICommand> 
            {
                new NorthCommand(1),
                new EastCommand(2),
                new SouthCommand(3),
                new WestCommand(2)
            };

            var commands = normalCommands.Concat(reversedCommands);

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var expected = new List<Position>
            {
                new Position(2, -3), new Position(3, -3), new Position(4, -3),
                new Position(4, -2), new Position(4, -1), new Position(4, 0),
                new Position(3, 0), new Position(2, 0),
                new Position(2, -1)
            };

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldNotCleanOutsideSpace()
        {
            const int spaceSize = 2;
            var startingPosition = new Position(-2, 2);
            var commands = new List<ICommand> 
            {
                new EastCommand(5),
                new SouthCommand(6),
                new WestCommand(100),
                new NorthCommand(100000)
            };

            var cleanedSpaces = new Robot(spaceSize, startingPosition, commands).Clean();

            var eastPositions = new List<Position>
            {
                new Position(-2, 2),
                new Position(-1, 2),
                new Position(0, 2),
                new Position(1, 2),
                new Position(2, 2)
            };

            var southPositions = new List<Position>
            {
                new Position(2, 1),
                new Position(2, 0),
                new Position(2, -1),
                new Position(2, -2)
            };

            var westPositions = new List<Position>
            {
                new Position(1, -2),
                new Position(0, -2),
                new Position(-1, -2),
                new Position(-2, -2)
            };

            var northPositions = new List<Position>
            {
                new Position(-2, -1),
                new Position(-2, 0),
                new Position(-2, 1)
            };

            var expected = eastPositions
                .Concat(southPositions)
                .Concat(westPositions)
                .Concat(northPositions);

            cleanedSpaces.Should().BeEquivalentTo(expected);
        }
    }
}