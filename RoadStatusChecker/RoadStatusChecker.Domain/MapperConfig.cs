using AutoMapper;
using RoadStatusChecker.Domain.Models;
using RoadStatusChecker.Repository.Models;

namespace RoadStatusChecker.Domain
{
    public static class MapperConfig
    {
        public static MapperConfiguration GetConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoadCorridor, RoadCorridorModel>();
            });

            return config;
        }
    }
}
