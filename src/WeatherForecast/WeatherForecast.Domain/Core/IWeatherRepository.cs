namespace WeatherForecast.Domain.Core
{
    public interface IWeatherRepository : IBaseRepository<Entities.WeatherForecast>
    {
        Task<IList<Entities.WeatherForecast>> GetWeeklyWeatherForecastAsync();
    }
}
