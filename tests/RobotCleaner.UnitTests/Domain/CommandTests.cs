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
            var startingPosition = (2, -3);
            const string direction = "Unknown";
            const int steps = 100;
            const int positionLimit = 10;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = (2, -3);
            var expectedPositions = new List<(int x, int y)>();

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldExecuteOnEastDirection()
        {
            var startingPosition = (2, -3);
            const string direction = "E";
            const int steps = 3;
            const int positionLimit = 10;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = (5, -3);
            var expectedPositions = new List<(int x, int y)> {(2, -3), (3, -3), (4, -3), (5, -3)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldExecuteOnWestDirection()
        {
            var startingPosition = (2, -3);
            const string direction = "W";
            const int steps = 3;
            const int positionLimit = 10;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = (-1, -3);
            var expectedPositions = new List<(int x, int y)> {(2, -3), (1, -3), (0, -3), (-1, -3)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldExecuteOnNorthDirection()
        {
            var startingPosition = (2, -3);
            const string direction = "N";
            const int steps = 3;
            const int positionLimit = 10;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = (2, 0);
            var expectedPositions = new List<(int x, int y)> {(2, -3), (2, -2), (2, -1), (2, 0)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldExecuteOnSouthDirection()
        {
            var startingPosition = (2, -3);
            const string direction = "S";
            const int steps = 3;
            const int positionLimit = 10;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = (2, -6);
            var expectedPositions = new List<(int x, int y)> {(2, -3), (2, -4), (2, -5), (2, -6)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }
    }
}