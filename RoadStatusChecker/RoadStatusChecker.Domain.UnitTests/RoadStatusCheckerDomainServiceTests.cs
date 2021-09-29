using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RoadStatusChecker.Domain.Models;
using RoadStatusChecker.Repository;
using RoadStatusChecker.Repository.Models;

namespace RoadStatusChecker.Domain.UnitTests
{
    public class RoadStatusCheckerDomainServiceTests
    {
        private readonly Mock<IRoadStatusCheckerRepository> _mockRepo = new Mock<IRoadStatusCheckerRepository>();

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
            var sut = new RoadStatusCheckerDomainService(_mockRepo.Object);
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
            var sut = new RoadStatusCheckerDomainService(_mockRepo.Object);

            Func<Task> task = async () =>
            {
                await sut.GetRoadCorridorsAsync("A2");
            };

            await task.Should().ThrowAsync<Exception>();
        }
    }
}
