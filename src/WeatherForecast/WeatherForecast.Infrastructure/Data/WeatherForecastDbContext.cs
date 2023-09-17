using Microsoft.EntityFrameworkCore;

namespace WeatherForecast.Infrastructure.Data
{
    public class WeatherForecastDbContext : DbContext
    {
        private static readonly WeatherForecastMaterializationInterceptor _weatherForecastInterceptor = new();

        public WeatherForecastDbContext()
        {
        }

        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .AddInterceptors(_weatherForecastInterceptor);

        public DbSet<Domain.Entities.WeatherForecast> Users { get; set; }
    }
}
