using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Domain.Core;
using WeatherForecast.Infrastructure.Data;
using WeatherForecast.Infrastructure.Repositories;

namespace WeatherForecast.Infrastructure
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<WeatherForecastDbContext>(options => options.UseInMemoryDatabase("TestDb"));
            services.AddDbContext<WeatherForecastDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IWeatherRepository), typeof(WeatherRepository));
        }
    }
}
