using WeatherForecast.Application.Models;

namespace WeatherForecast.Application.Interfaces
{
    public interface IWeatherService
    {
        Task<int> AddWeatherForecastAsync(AddWeatherForecastRequest req);

        Task<WeatherForecastDto> GetWeatherForecastAsync(int id);

        Task<IList<WeatherForecastDto>> GetWeeklyWeatherForecastAsync();
    }
}
