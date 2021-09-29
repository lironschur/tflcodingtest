using System.Collections.Generic;
using System.Threading.Tasks;
using RoadStatus.Domain.Models;

namespace RoadStatus.Domain
{
    public interface IRoadStatusDomainService
    {
        Task<IEnumerable<RoadCorridorModel>> GetRoadCorridorsAsync(string id);
    }
}