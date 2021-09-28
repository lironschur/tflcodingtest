using System.Collections.Generic;
using System.Threading.Tasks;
using RoadStatusChecker.Domain;
using RoadStatusChecker.Service.ViewModels;

namespace RoadStatusChecker.Service
{
    public class RoadStatusCheckerService : IRoadStatusCheckerService
    {
        private readonly IRoadStatusCheckerDomainService _roadStatusCheckerDomainService;

        public RoadStatusCheckerService(IRoadStatusCheckerDomainService roadStatusCheckerDomainService)
        {
            _roadStatusCheckerDomainService = roadStatusCheckerDomainService;
        }
        public async Task<IEnumerable<RoadCorridorViewModel>> GetRoadCorridorsAsync(string id)
        {
            var domain = await _roadStatusCheckerDomainService.GetRoadCorridorsAsync(id);
            var mapper = MapperConfig.GetConfiguration().CreateMapper();
            var result = mapper.Map<IEnumerable<RoadCorridorViewModel>>(domain);
            return result;
        }
    }
}
