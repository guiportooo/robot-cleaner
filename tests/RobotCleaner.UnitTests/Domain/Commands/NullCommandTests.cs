using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using RobotCleaner.App.Domain;
using RobotCleaner.App.Domain.Commands;

namespace RobotCleaner.UnitTests.Domain.Commands
{
    public class NullCommandTests
    {
        [Test]
        public void ShouldReturnOnlyStartingPosition()
        {
            var startingPosition = new Position(2, -3);
            const int steps = 3;
            const int positionLimit = 10;

            var command = new NullCommand(steps);
            var (lastPosition, positions) = command.Execute(startingPosition, positionLimit);

            var expectedLastPosition = new Position(2, -3);
            var expectedPositions = new List<Position>
            {
                new Position(2, -3)
            };

            lastPosition.Should().Be(expectedLastPosition);
            positions.Should().BeEquivalentTo(expectedPositions);
        }
    }
}