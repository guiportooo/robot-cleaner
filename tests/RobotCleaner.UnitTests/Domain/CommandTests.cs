using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using RobotCleaner.App.Domain;

namespace RobotCleaner.UnitTests.Domain
{
    public class CommandTests
    {
        [Test]
        public void ShouldNotExecuteIfDirectionIsUnknown()
        {
            var startingPosition = new Position(2, -3);
            const string direction = "Unknown";
            const int steps = 100;
            const int positionLimit = 10;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = new Position(2, -3);
            var expectedPositions = new List<Position>();

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldExecuteOnEastDirection()
        {
            var startingPosition = new Position(2, -3);
            const string direction = "E";
            const int steps = 3;
            const int positionLimit = 10;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = new Position(5, -3);
            var expectedPositions = new List<Position>
            {
                new Position(2, -3), 
                new Position(3, -3), 
                new Position(4, -3), 
                new Position(5, -3)
            };

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldExecuteOnWestDirection()
        {
            var startingPosition = new Position(2, -3);
            const string direction = "W";
            const int steps = 3;
            const int positionLimit = 10;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = new Position(-1, -3);
            var expectedPositions = new List<Position>
            {
                new Position(2, -3), 
                new Position(1, -3), 
                new Position(0, -3), 
                new Position(-1, -3)
            };

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldExecuteOnNorthDirection()
        {
            var startingPosition = new Position(2, -3);
            const string direction = "N";
            const int steps = 3;
            const int positionLimit = 10;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = new Position(2, 0);
            var expectedPositions = new List<Position>
            {
                new Position(2, -3), 
                new Position(2, -2), 
                new Position(2, -1), 
                new Position(2, 0)
            };

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldExecuteOnSouthDirection()
        {
            var startingPosition = new Position(2, -3);
            const string direction = "S";
            const int steps = 3;
            const int positionLimit = 10;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = new Position(2, -6);
            var expectedPositions = new List<Position>
            {
                new Position(2, -3), 
                new Position(2, -4), 
                new Position(2, -5), 
                new Position(2, -6)
            };

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }
    }
}