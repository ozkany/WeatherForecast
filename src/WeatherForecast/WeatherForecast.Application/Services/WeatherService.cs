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

        public async Task<bool> AddWeatherForecast(AddWeatherForecastRequest req)
        {
            var weatherForecast = _mapper.Map<Domain.Entities.WeatherForecast>(req);

            await _repository.AddAsync(weatherForecast);

            return await _repository.SaveChangesAsync() > 0;
        }

        public async Task<IList<WeatherForecastDto>> GetWeeklyWeatherForecasts()
        {
            var weatherForecasts = await _repository.ListAllAsync();

            var weatherForecastsDto = _mapper.Map<List<WeatherForecastDto>>(weatherForecasts);

            return weatherForecastsDto;
        }
    }
}
