using WeatherForecast.Application.Models;

namespace WeatherForecast.Application.Interfaces
{
    public interface IWeatherService
    {
        Task<bool> AddWeatherForecast(AddWeatherForecastRequest req);

        Task<IList<WeatherForecastDto>> GetWeeklyWeatherForecasts();
    }
}
