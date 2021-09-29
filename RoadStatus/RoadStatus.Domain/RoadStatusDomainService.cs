using System.Collections.Generic;
using System.Threading.Tasks;
using RoadStatus.Domain.Models;
using RoadStatus.Repository;

namespace RoadStatus.Domain
{
    public class RoadStatusDomainService : IRoadStatusDomainService
    {
        private readonly IRoadStatusRepository _roadStatusRepository;

        public RoadStatusDomainService(IRoadStatusRepository roadStatusRepository)
        {
            _roadStatusRepository = roadStatusRepository;
        }

        public async Task<IEnumerable<RoadCorridorModel>> GetRoadCorridorsAsync(string id)
        {
            var repo = await _roadStatusRepository.GetRoadCorridorsAsync(id);
            var mapper = MapperConfig.GetConfiguration().CreateMapper();
            var results = mapper.Map<IEnumerable<RoadCorridorModel>>(repo);
            return results;
        }
    }
}
