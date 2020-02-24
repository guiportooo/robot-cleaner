using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using RobotCleaner.App.Domain;
using RobotCleaner.App.Domain.Commands;

namespace RobotCleaner.UnitTests.Domain
{
    public class RobotBuilderTests
    {
        [Test]
        public void ShouldBuildRobotWithDefaultValues()
        {
            var robot = new RobotBuilder()
                .Build();

            const int expectedSpaceSize = RobotBuilder.SpaceSize;
            var expectedPosition = new Position(0, 0);
            var expectedCommands = new List<ICommand>();

            robot.SpaceSize.Should().Be(expectedSpaceSize);
            robot.Position.Should().Be(expectedPosition);
            robot.Commands.Should().BeEquivalentTo(expectedCommands);
        }

        [Test]
        public void ShouldBuildRobotWithStartingPosition()
        {
            const string startingPosition = "2 -3";

            var robot = new RobotBuilder()
                .StartingAt(startingPosition)
                .Build();

            const int expectedSpaceSize = RobotBuilder.SpaceSize;
            var expectedPosition = new Position(2, -3);
            var expectedCommands = new List<ICommand>();

            robot.SpaceSize.Should().Be(expectedSpaceSize);
            robot.Position.Should().Be(expectedPosition);
            robot.Commands.Should().BeEquivalentTo(expectedCommands);
        }

        [Test]
        public void ShouldBuildRobotWithCommands()
        {
            const string numberOfCommands = "5";
            var commands = new[]
            {
                "E 1",
                "W 100000",
                "N 45829",
                "S 0",
                "U 10"
            };

            var index = 0;
            Func<string> getCommandInput = () =>
            {
                var command = commands[index];
                index++;
                return command;
            };

            var robot = new RobotBuilder()
                .WithNumberOfCommands(numberOfCommands)
                .WithCommands(getCommandInput)
                .Build();

            const int expectedSpaceSize = RobotBuilder.SpaceSize;
            var expectedPosition = new Position(0, 0);
            var expectedCommands = new List<ICommand>
            {
                new EastCommand(1),
                new WestCommand(100000),
                new NorthCommand(45829),
                new SouthCommand(0),
                new NullCommand(10)
            };

            robot.SpaceSize.Should().Be(expectedSpaceSize);
            robot.Position.Should().Be(expectedPosition);
            robot.Commands.Should().BeEquivalentTo(expectedCommands, o => o.RespectingRuntimeTypes());
        }

        [Test]
        public void ShouldRespectNumberOfCommands()
        {
            const string numberOfCommands = "2";
            var commands = new[]
            {
                "E 1",
                "W 100000",
                "N 45829",
                "S 0",
                "U 10"
            };

            var index = 0;
            Func<string> getCommandInput = () =>
            {
                var command = commands[index];
                index++;
                return command;
            };

            var robot = new RobotBuilder()
                .WithNumberOfCommands(numberOfCommands)
                .WithCommands(getCommandInput)
                .Build();

            const int expectedSpaceSize = RobotBuilder.SpaceSize;
            var expectedPosition = new Position(0, 0);
            var expectedCommands = new List<ICommand>
            {
                new EastCommand(1),
                new WestCommand(100000)
            };

            robot.SpaceSize.Should().Be(expectedSpaceSize);
            robot.Position.Should().Be(expectedPosition);
            robot.Commands.Should().BeEquivalentTo(expectedCommands, o => o.RespectingRuntimeTypes());
        }
    }
}