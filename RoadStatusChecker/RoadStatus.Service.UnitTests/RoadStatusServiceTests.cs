using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RoadStatus.Domain;
using RoadStatus.Domain.Models;
using RoadStatus.Service.ViewModels;

namespace RoadStatus.Service.UnitTests
{
    public class RoadStatusServiceTests
    {
        private readonly Mock<IRoadStatusDomainService> _mockDomainService = new Mock<IRoadStatusDomainService>();
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
            var sut = new RoadStatusService(_mockDomainService.Object);
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


        [Test]
        public async Task GetRoadCorridorsAsync_LetsExceptionBubbleThrough()
        {
            _mockDomainService.Setup(x => x.GetRoadCorridorsAsync("A2")).ThrowsAsync(new Exception("test"));

            //When
            var sut = new RoadStatusService(_mockDomainService.Object);

            Func<Task> task = async () =>
            {
                await sut.GetRoadCorridorsAsync("A2");
            };

            await task.Should().ThrowAsync<Exception>();
        }
    }
}