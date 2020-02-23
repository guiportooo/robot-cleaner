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

        [Test]
        public void ShouldNotExecuteOutsideLimitOnEastDirectionWhenOnPositivePosition()
        {
            var startingPosition = (2, 0);
            const string direction = "E";
            const int steps = 5;
            const int positionLimit = 4;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = (4, 0);
            var expectedPositions = new List<(int x, int y)> {(2, 0), (3, 0), (4, 0)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldNotExecuteOutsideLimitOnEastDirectionWhenOnNegativePosition()
        {
            var startingPosition = (-1, 0);
            const string direction = "E";
            const int steps = 5;
            const int positionLimit = 2;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = (2, 0);
            var expectedPositions = new List<(int x, int y)> {(-1, 0), (0, 0), (1, 0), (2, 0)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldNotExecuteOutsideLimitOnWestDirectionWhenOnPositivePosition()
        {
            var startingPosition = (1, 0);
            const string direction = "W";
            const int steps = 5;
            const int positionLimit = 2;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = (-2, 0);
            var expectedPositions = new List<(int x, int y)> {(1, 0), (0, 0), (-1, 0), (-2, 0)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldNotExecuteOutsideLimitOnWestDirectionWhenOnNegativePosition()
        {
            var startingPosition = (-2, 0);
            const string direction = "W";
            const int steps = 5;
            const int positionLimit = 4;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = (-4, 0);
            var expectedPositions = new List<(int x, int y)> {(-2, 0), (-3, 0), (-4, 0)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldNotExecuteOutsideLimitOnNorthDirectionWhenOnPositivePosition()
        {
            var startingPosition = (0, 2);
            const string direction = "N";
            const int steps = 5;
            const int positionLimit = 4;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = (0, 4);
            var expectedPositions = new List<(int x, int y)> {(0, 2), (0, 3), (0, 4)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldNotExecuteOutsideLimitOnNorthDirectionWhenOnNegativePosition()
        {
            var startingPosition = (0, -1);
            const string direction = "N";
            const int steps = 5;
            const int positionLimit = 2;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = (0, 2);
            var expectedPositions = new List<(int x, int y)> {(0, -1), (0, 0), (0, 1), (0, 2)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldNotExecuteOutsideLimitOnSouthDirectionWhenOnPositivePosition()
        {
            var startingPosition = (0, 1);
            const string direction = "S";
            const int steps = 5;
            const int positionLimit = 2;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = (0, -2);
            var expectedPositions = new List<(int x, int y)> {(0, 1), (0, 0), (0, -1), (0, -2)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldNotExecuteOutsideLimitOnSouthDirectionWhenOnNegativePosition()
        {
            var startingPosition = (0, -2);
            const string direction = "S";
            const int steps = 5;
            const int positionLimit = 4;

            var (lastPosition, positions) = Command.Execute(startingPosition,
                direction,
                steps,
                positionLimit);

            var expectedLastPosition = (0, -4);
            var expectedPositions = new List<(int x, int y)> {(0, -2), (0, -3), (0, -4)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }
    }
}