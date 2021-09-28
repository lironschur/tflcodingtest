using AutoMapper;
using RoadStatusChecker.Domain.Models;
using RoadStatusChecker.Service.ViewModels;

namespace RoadStatusChecker.Service
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
