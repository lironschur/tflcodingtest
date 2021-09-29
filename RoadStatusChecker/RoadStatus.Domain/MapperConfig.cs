using AutoMapper;
using RoadStatus.Domain.Models;
using RoadStatus.Repository.Models;

namespace RoadStatus.Domain
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
