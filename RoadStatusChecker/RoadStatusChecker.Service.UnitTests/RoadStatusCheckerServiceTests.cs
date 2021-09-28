using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RoadStatusChecker.Domain;
using RoadStatusChecker.Domain.Models;
using RoadStatusChecker.Service.ViewModels;

namespace RoadStatusChecker.Service.UnitTests
{
    public class RoadStatusCheckerServiceTests
    {
        private readonly Mock<IRoadStatusCheckerDomainService> _mockDomainService = new Mock<IRoadStatusCheckerDomainService>();
        [Test]
        public async Task GetRoadCorridorsAsync_ReturnsCorrectResult()
        {
            // Given
            var domain = new List<RoadCorridorModel>()
            {
                new RoadCorridorModel
                {
                    Id = "id1",
                    DisplayName = "displayName",
                    StatusSeverity = "good",
                    StatusSeverityDescription = "good flow"
                }
            };

            _mockDomainService.Setup(x => x.GetRoadCorridorsAsync("id1")).ReturnsAsync(domain);

            //When
            var sut = new RoadStatusCheckerService(_mockDomainService.Object);
            var result = await sut.GetRoadCorridorsAsync("id1");

            var expected = new List<RoadCorridorViewModel>()
            {
                new RoadCorridorViewModel
                {
                    Id = "id1",
                    DisplayName = "displayName",
                    StatusSeverity = "good",
                    StatusSeverityDescription = "good flow"
                }
            };

            // Then
            result.Should().BeEquivalentTo(expected);
        }
    }
}