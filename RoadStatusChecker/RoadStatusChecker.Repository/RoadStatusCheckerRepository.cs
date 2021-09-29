using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoadStatusChecker.Repository.Models;

namespace RoadStatusChecker.Repository
{
    public class RoadStatusCheckerRepository : IRoadStatusCheckerRepository
    {
        public async Task<IEnumerable<RoadCorridor>> GetRoadCorridorsAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
