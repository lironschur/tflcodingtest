using System.Collections.Generic;
using System.Threading.Tasks;
using RoadStatus.Domain;
using RoadStatus.Service.ViewModels;

namespace RoadStatus.Service
{
    public class RoadStatusService : IRoadStatusService
    {
        private readonly IRoadStatusDomainService _roadStatusDomainService;

        public RoadStatusService(IRoadStatusDomainService roadStatusDomainService)
        {
            _roadStatusDomainService = roadStatusDomainService;
        }

        public async Task<IEnumerable<RoadCorridorViewModel>> GetRoadCorridorsAsync(string id)
        {
            var domain = await _roadStatusDomainService.GetRoadCorridorsAsync(id);
            var mapper = MapperConfig.GetConfiguration().CreateMapper();
            var result = mapper.Map<IEnumerable<RoadCorridorViewModel>>(domain);
            return result;
        }
    }
}
