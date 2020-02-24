using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using RobotCleaner.App.Domain;
using RobotCleaner.App.Domain.Commands;

namespace RobotCleaner.UnitTests.Domain.Commands
{
    public class NorthCommandTests
    {
        [Test]
        public void ShouldExecute()
        {
            var startingPosition = new Position(2, -3);
            const int steps = 3;
            const int positionLimit = 10;

            var command = new NorthCommand(steps);
            var (lastPosition, positions) = command.Execute(startingPosition, positionLimit);

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
        public void ShouldNotExecuteOutsideLimitsWhenOnPositivePosition()
        {
            var startingPosition = new Position(0, 2);
            const int steps = 5;
            const int positionLimit = 4;

            var command = new NorthCommand(steps);
            var (lastPosition, positions) = command.Execute(startingPosition, positionLimit);

            var expectedLastPosition = new Position(0, 4);
            var expectedPositions = new List<Position>
            {
                new Position(0, 2), 
                new Position(0, 3), 
                new Position(0, 4)
            };

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldNotExecuteOutsideLimitsWhenOnNegativePosition()
        {
            var startingPosition = new Position(0, -1);
            const int steps = 5;
            const int positionLimit = 2;

            var command = new NorthCommand(steps);
            var (lastPosition, positions) = command.Execute(startingPosition, positionLimit);

            var expectedLastPosition = new Position(0, 2);
            var expectedPositions = new List<Position>
            {
                new Position(0, -1), 
                new Position(0, 0), 
                new Position(0, 1), 
                new Position(0, 2)
            };

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }
    }
}