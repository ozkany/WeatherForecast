using AutoMapper;
using WeatherForecast.Application.Models;

namespace WeatherForecast.Application.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.WeatherForecast, WeatherForecastDto>();
                //.ForMember(dto => dto.Summary, e => e.MapFrom((src, dest) =>
                //{
                //    int i = (int)Math.Ceiling((double)(src.Temperature + 60) / 12);
                //    return WeatherForecastDto.Summaries.Length >= i ? WeatherForecastDto.Summaries[i - 1] : string.Empty;
                //}));
            CreateMap<AddWeatherForecastRequest, Domain.Entities.WeatherForecast>();
        }
    }
}
