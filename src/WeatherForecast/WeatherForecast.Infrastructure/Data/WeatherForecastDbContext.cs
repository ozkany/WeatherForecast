using Microsoft.EntityFrameworkCore;

namespace WeatherForecast.Infrastructure.Data
{
    public class WeatherForecastDbContext : DbContext
    {
        public WeatherForecastDbContext()
        {
        }

        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.WeatherForecast> Users { get; set; }
    }
}
