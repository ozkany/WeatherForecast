using Microsoft.EntityFrameworkCore.Diagnostics;

namespace WeatherForecast.Infrastructure.Data
{
    public class WeatherForecastMaterializationInterceptor : IMaterializationInterceptor
    {
        public object InitializedInstance(MaterializationInterceptionData materializationData, object instance)
        {
            if (instance is Domain.Entities.WeatherForecast weatherForecast)
            {
                int i = Math.Max(0, Math.Min(Summaries.Length - 1, (int)Math.Ceiling((double)(weatherForecast.Temperature + 60) / 12)));
                weatherForecast.Summary = Summaries[i];
            }

            return instance;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }
}
