using AutoMapper;
using RoadStatus.Domain.Models;
using RoadStatus.Service.ViewModels;

namespace RoadStatus.Service
{
    public static class MapperConfig
    {
        public static MapperConfiguration GetConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoadCorridorModel, RoadCorridorViewModel>();
            });

            return config;
        }
    }
}
