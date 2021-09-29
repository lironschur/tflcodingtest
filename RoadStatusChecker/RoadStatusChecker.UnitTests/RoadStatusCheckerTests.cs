using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RoadStatusChecker.Service;
using RoadStatusChecker.Service.ViewModels;

namespace RoadStatusChecker.UnitTests
{
    public class RoadStatusCheckerTests
    {
        private readonly Mock<IRoadStatusCheckerService> _mockService = new Mock<IRoadStatusCheckerService>();
        private readonly Mock<IConsoleLogger> _mockLogger = new Mock<IConsoleLogger>();

        [Test]
        public async Task GetRoadCorridorsAsync_DisplaysRoadInfo()
        {
            // Given
            _mockService.Setup(x => x.GetRoadCorridorsAsync("id1"))
                .ReturnsAsync(new List<RoadCorridorViewModel>
                {
                    new RoadCorridorViewModel
                    {
                        Id = "id1",
                        DisplayName = "road1",
                        StatusSeverity = "good",
                        StatusSeverityDescription = "very good"
                    }
                });

            // When
            var sut = new RoadStatusCheckerApp(_mockService.Object, _mockLogger.Object);
            var result = await sut.GetRoadStatusAsync("id1");

            // Then
            result.Should().Be(0);
            _mockLogger.Verify(x => x.WriteLine("The status of the road1 is as follows"), Times.Once);
            _mockLogger.Verify(x => x.WriteLine("\tRoad Status is good"), Times.Once);
            _mockLogger.Verify(x => x.WriteLine("\tRoad Status Description is very good"), Times.Once);
        }

        [Test]
        public async Task GetRoadCorridorsAsync_NoRoadFoundReturnsErrorCode()
        {
            // Given
            _mockService.Setup(x => x.GetRoadCorridorsAsync("noSuchRoad"))
                .ThrowsAsync(new RoadNotFoundException());

            // When
            var sut = new RoadStatusCheckerApp(_mockService.Object, _mockLogger.Object);
            var result = await sut.GetRoadStatusAsync("noSuchRoad");

            // Then
            result.Should().Be(1);
            _mockLogger.Verify(x => x.WriteLine($"noSuchRoad is not a valid road"), Times.Once);
        }
    }
}