using AutoMapper;
using WeatherForecast.Application.Interfaces;
using WeatherForecast.Application.Models;
using WeatherForecast.Domain.Core;

namespace WeatherForecast.Application.Services
{
    public class WeatherService : IWeatherService
    {
        IBaseRepository<Domain.Entities.WeatherForecast> _repository;
        private readonly IMapper _mapper;

        public WeatherService(IBaseRepository<Domain.Entities.WeatherForecast> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<bool> CreateWeatherForecast(AddWeatherForecastRequest req)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<WeatherForecastDto>> GetWeatherForecasts()
        {
            throw new NotImplementedException();
        }
    }
}
