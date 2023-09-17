using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Core;
using WeatherForecast.Infrastructure.Data;

namespace WeatherForecast.Infrastructure.Repositories
{
    public class WeatherRepository : BaseRepository<Domain.Entities.WeatherForecast>, IWeatherRepository
    { 
        public WeatherRepository(WeatherForecastDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Domain.Entities.WeatherForecast>> GetWeeklyWeatherForecastAsync()
        {
            return await _dbContext.WeatherForecasts.Where(w => w.Date >= DateTime.Today && w.Date <= DateTime.Today.AddDays(7)).ToListAsync();
        }
    }
}
