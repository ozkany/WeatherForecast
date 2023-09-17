using AutoMapper;
using WeatherForecast.Application.Interfaces;
using WeatherForecast.Application.Models;
using WeatherForecast.Domain.Core;

namespace WeatherForecast.Application.Services
{
    public class WeatherService : IWeatherService
    {
        IWeatherRepository _repository;
        private readonly IMapper _mapper;

        public WeatherService(IWeatherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddWeatherForecastAsync(AddWeatherForecastRequest request)
        {
            var weatherForecast = _mapper.Map<Domain.Entities.WeatherForecast>(request);

            await _repository.AddAsync(weatherForecast);

            await _repository.SaveChangesAsync();

            return weatherForecast.Id;
        }

        public async Task<WeatherForecastDto> GetWeatherForecastAsync(int id)
        {
            var weatherForecast = await _repository.GetByIdAsync(id);

            var weatherForecastDto = _mapper.Map<WeatherForecastDto>(weatherForecast);

            return weatherForecastDto;
        }

        public async Task<IList<WeatherForecastDto>> GetWeeklyWeatherForecastAsync()
        {
            var weatherForecasts = await _repository.GetWeeklyWeatherForecastAsync();

            var weatherForecastsDto = _mapper.Map<List<WeatherForecastDto>>(weatherForecasts);

            return weatherForecastsDto;
        }
    }
}
