using AutoMapper;
using WeatherForecast.Application.Models;

namespace WeatherForecast.Application.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.WeatherForecast, WeatherForecastDto>();
            CreateMap<AddWeatherForecastRequest, Domain.Entities.WeatherForecast>();
        }
    }
}
