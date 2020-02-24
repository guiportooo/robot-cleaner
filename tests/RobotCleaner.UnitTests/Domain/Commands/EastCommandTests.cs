using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using RobotCleaner.App.Domain;
using RobotCleaner.App.Domain.Commands;

namespace RobotCleaner.UnitTests.Domain.Commands
{
    public class EastCommandTests
    {
        [Test]
        public void ShouldExecute()
        {
            var startingPosition = new Position(2, -3);
            const int steps = 3;
            const int positionLimit = 10;

            var command = new EastCommand(steps);
            var (lastPosition, positions) = command.Execute(startingPosition, positionLimit);

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
        public void ShouldNotExecuteOutsideLimitsWhenOnPositivePosition()
        {
            var startingPosition = new Position(2, 0);
            const int steps = 5;
            const int positionLimit = 4;

            var command = new EastCommand(steps);
            var (lastPosition, positions) = command.Execute(startingPosition, positionLimit);
            
            var expectedLastPosition = new Position(4, 0);
            var expectedPositions = new List<Position>
            {
                new Position(2, 0), 
                new Position(3, 0), 
                new Position(4, 0)
            };

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }

        [Test]
        public void ShouldNotExecuteOutsideLimitsWhenOnNegativePosition()
        {
            var startingPosition = new Position(-1, 0);
            const int steps = 5;
            const int positionLimit = 2;

            var command = new EastCommand(steps);
            var (lastPosition, positions) = command.Execute(startingPosition, positionLimit);
            
            var expectedLastPosition = new Position(2, 0);
            var expectedPositions = new List<Position>
            {
                new Position(-1, 0), 
                new Position(0, 0), 
                new Position(1, 0), 
                new Position(2, 0)
            };

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }
    }
}