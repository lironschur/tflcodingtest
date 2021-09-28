using System.Collections.Generic;
using System.Threading.Tasks;
using RoadStatusChecker.Service.ViewModels;

namespace RoadStatusChecker.Service
{
    public interface IRoadStatusCheckerService
    {
        public Task<IEnumerable<RoadCorridorViewModel>> GetRoadCorridorsAsync(string id);
    }
}