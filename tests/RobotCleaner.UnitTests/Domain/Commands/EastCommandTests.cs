using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using RobotCleaner.App.Domain.Commands;

namespace RobotCleaner.UnitTests.Domain.Commands
{
    public class EastCommandTests
    {
        [Test]
        public void ShouldExecute()
        {
            var startingPosition = (2, -3);
            const int steps = 3;
            const int positionLimit = 10;

            var command = new EastCommand(startingPosition, positionLimit);
            var (lastPosition, positions) = command.Execute(steps);

            var expectedLastPosition = (5, -3);
            var expectedPositions = new List<(int x, int y)> {(2, -3), (3, -3), (4, -3), (5, -3)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldNotExecuteOutsideLimitsWhenOnPositivePosition()
        {
            var startingPosition = (2, 0);
            const int steps = 5;
            const int positionLimit = 4;

            var command = new EastCommand(startingPosition, positionLimit);
            var (lastPosition, positions) = command.Execute(steps);
            
            var expectedLastPosition = (4, 0);
            var expectedPositions = new List<(int x, int y)> {(2, 0), (3, 0), (4, 0)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldNotExecuteOutsideLimitsWhenOnNegativePosition()
        {
            var startingPosition = (-1, 0);
            const int steps = 5;
            const int positionLimit = 2;

            var command = new EastCommand(startingPosition, positionLimit);
            var (lastPosition, positions) = command.Execute(steps);
            
            var expectedLastPosition = (2, 0);
            var expectedPositions = new List<(int x, int y)> {(-1, 0), (0, 0), (1, 0), (2, 0)};

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }
    }
}