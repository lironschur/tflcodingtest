using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoadStatusChecker.Domain.Models;

namespace RoadStatusChecker.Domain
{
    public class RoadStatusCheckerDomainService : IRoadStatusCheckerDomainService
    {
        public async Task<IEnumerable<RoadCorridorModel>> GetRoadCorridorsAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
