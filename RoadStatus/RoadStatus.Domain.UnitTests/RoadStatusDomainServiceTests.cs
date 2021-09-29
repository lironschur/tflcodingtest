using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RoadStatus.Domain.Models;
using RoadStatus.Repository;
using RoadStatus.Repository.Models;

namespace RoadStatus.Domain.UnitTests
{
    public class RoadStatusDomainServiceTests
    {
        private readonly Mock<IRoadStatusRepository> _mockRepo = new Mock<IRoadStatusRepository>();

        [Test]
        public async Task GetRoadCorridorsAsync_ReturnsCorrectResult()
        {
            // Given
            var repo = new List<RoadCorridor>()
            {
                new RoadCorridor
                {
                    Id = "id1",
                    DisplayName = "displayName",
                    StatusSeverity = "good",
                    StatusSeverityDescription = "good flow"
                }
            };

            _mockRepo.Setup(x => x.GetRoadCorridorsAsync("id1")).ReturnsAsync(repo);

            //When
            var sut = new RoadStatusDomainService(_mockRepo.Object);
            var result = await sut.GetRoadCorridorsAsync("id1");

            var expected = new List<RoadCorridorModel>
            {
                new RoadCorridorModel
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
            _mockRepo.Setup(x => x.GetRoadCorridorsAsync("A2")).ThrowsAsync(new Exception("test"));

            //When
            var sut = new RoadStatusDomainService(_mockRepo.Object);

            Func<Task> task = async () =>
            {
                await sut.GetRoadCorridorsAsync("A2");
            };

            await task.Should().ThrowAsync<Exception>();
        }
    }
}
