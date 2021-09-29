using System;
using System.Collections.Generic;
using System.Net.Http;
using RoadStatusChecker.Domain.Models;
using System.Threading.Tasks;
using RoadStatusChecker.Repository;

namespace RoadStatusChecker.Domain
{
    public class RoadStatusCheckerDomainService : IRoadStatusCheckerDomainService
    {
        private readonly IRoadStatusCheckerRepository _roadStatusCheckerRepository;

        public RoadStatusCheckerDomainService(IRoadStatusCheckerRepository roadStatusCheckerRepository)
        {
            _roadStatusCheckerRepository = roadStatusCheckerRepository;
        }

        public async Task<IEnumerable<RoadCorridorModel>> GetRoadCorridorsAsync(string id)
        {
            var repo = await _roadStatusCheckerRepository.GetRoadCorridorsAsync(id);
            var mapper = MapperConfig.GetConfiguration().CreateMapper();
            var results = mapper.Map<IEnumerable<RoadCorridorModel>>(repo);
            return results;
        }
    }
}
