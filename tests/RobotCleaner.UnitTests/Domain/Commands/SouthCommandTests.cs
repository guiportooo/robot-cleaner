using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using RobotCleaner.App.Domain.Commands;

namespace RobotCleaner.UnitTests.Domain.Commands
{
    public class SouthCommandTests
    {
        [Test]
        public void ShouldExecute()
        {
            var startingPosition = (2, -3);
            const int steps = 3;
            const int positionLimit = 10;

            var command = new SouthCommand(startingPosition, positionLimit);
            var (lastPosition, positions) = command.Execute(steps);

            var expectedLastPosition = (2, -6);
            var expectedPositions = new List<(int x, int y)> {(2, -3), (2, -4), (2, -5), (2, -6)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldNotExecuteOutsideLimitOnSouthDirectionWhenOnPositivePosition()
        {
            var startingPosition = (0, 1);
            const int steps = 5;
            const int positionLimit = 2;

            var command = new SouthCommand(startingPosition, positionLimit);
            var (lastPosition, positions) = command.Execute(steps);

            var expectedLastPosition = (0, -2);
            var expectedPositions = new List<(int x, int y)> {(0, 1), (0, 0), (0, -1), (0, -2)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldNotExecuteOutsideLimitOnSouthDirectionWhenOnNegativePosition()
        {
            var startingPosition = (0, -2);
            const int steps = 5;
            const int positionLimit = 4;

            var command = new SouthCommand(startingPosition, positionLimit);
            var (lastPosition, positions) = command.Execute(steps);

            var expectedLastPosition = (0, -4);
            var expectedPositions = new List<(int x, int y)> {(0, -2), (0, -3), (0, -4)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }
    }
}