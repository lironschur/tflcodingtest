using System.Collections.Generic;
using System.Threading.Tasks;
using RoadStatusChecker.Domain.Models;

namespace RoadStatusChecker.Domain
{
    public interface IRoadStatusCheckerDomainService
    {
        Task<IEnumerable<RoadCorridorModel>> GetRoadCorridorsAsync(string id);
    }
}