using System.Collections.Generic;
using System.Threading.Tasks;
using RoadStatus.Service.ViewModels;

namespace RoadStatus.Service
{
    public interface IRoadStatusService
    {
        public Task<IEnumerable<RoadCorridorViewModel>> GetRoadCorridorsAsync(string id);
    }
}