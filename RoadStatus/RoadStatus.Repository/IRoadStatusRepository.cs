using System.Collections.Generic;
using System.Threading.Tasks;
using RoadStatus.Repository.Models;

namespace RoadStatus.Repository
{
    public interface IRoadStatusRepository
    {
        public Task<IEnumerable<RoadCorridor>> GetRoadCorridorsAsync(string id);
    }
}