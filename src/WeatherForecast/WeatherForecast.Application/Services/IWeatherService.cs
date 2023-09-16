using WeatherForecast.Application.Models;

namespace WeatherForecast.Application.Interfaces
{
    public interface IWeatherService
    {
        Task<bool> CreateWeatherForecast(AddWeatherForecastRequest req);

        Task<IReadOnlyCollection<WeatherForecastDto>> GetWeatherForecasts();
    }
}
