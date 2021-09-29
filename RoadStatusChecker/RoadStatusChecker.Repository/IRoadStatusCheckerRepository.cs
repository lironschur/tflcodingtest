using System.Collections.Generic;
using System.Threading.Tasks;
using RoadStatusChecker.Repository.Models;

namespace RoadStatusChecker.Repository
{
    public interface IRoadStatusCheckerRepository
    {
        public Task<IEnumerable<RoadCorridor>> GetRoadCorridorsAsync(string id);
    }
}