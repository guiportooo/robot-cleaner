using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using RobotCleaner.App.Domain;
using RobotCleaner.App.Domain.Commands;

namespace RobotCleaner.UnitTests.Domain.Commands
{
    public class SouthCommandTests
    {
        [Test]
        public void ShouldExecute()
        {
            var startingPosition = new Position(2, -3);
            const int steps = 3;
            const int positionLimit = 10;

            var command = new SouthCommand(startingPosition, positionLimit);
            var (lastPosition, positions) = command.Execute(steps);

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

        [Test]
        public void ShouldNotExecuteOutsideLimitOnSouthDirectionWhenOnPositivePosition()
        {
            var startingPosition = new Position(0, 1);
            const int steps = 5;
            const int positionLimit = 2;

            var command = new SouthCommand(startingPosition, positionLimit);
            var (lastPosition, positions) = command.Execute(steps);

            var expectedLastPosition = new Position(0, -2);
            var expectedPositions = new List<Position>
            {
                new Position(0, 1), 
                new Position(0, 0), 
                new Position(0, -1), 
                new Position(0, -2)
            };

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldNotExecuteOutsideLimitOnSouthDirectionWhenOnNegativePosition()
        {
            var startingPosition = new Position(0, -2);
            const int steps = 5;
            const int positionLimit = 4;

            var command = new SouthCommand(startingPosition, positionLimit);
            var (lastPosition, positions) = command.Execute(steps);

            var expectedLastPosition = new Position(0, -4);
            var expectedPositions = new List<Position>
            {
                new Position(0, -2), 
                new Position(0, -3), 
                new Position(0, -4)
            };

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }
    }
}