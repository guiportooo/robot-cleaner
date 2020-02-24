using Moq.AutoMock;
using NUnit.Framework;
using RobotCleaner.App.Domain;

namespace RobotCleaner.UnitTests.Domain
{
    public class RobotRunnerTests
    {
        [Test]
        public void ShouldDisplayNumberOfCleanedSpaces()
        {
            const int expectedCleanedSpaces = 4;
            
            var mocker = new AutoMocker();
            var robotRunner = mocker.CreateInstance<RobotRunner>();
            var displayMock = mocker.GetMock<IDisplay>();

            displayMock.SetupSequence(x => x.GetInput())
                .Returns("2")
                .Returns("10 22")
                .Returns("E 2")
                .Returns("N 1");
            
            robotRunner.Run();
            
            displayMock
                .Verify(x => x.ShowOutput($"Cleaned: {expectedCleanedSpaces}"));
        }
    }
}