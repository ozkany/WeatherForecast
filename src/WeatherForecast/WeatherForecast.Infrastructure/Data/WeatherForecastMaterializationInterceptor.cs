using Microsoft.EntityFrameworkCore.Diagnostics;
using Common = WeatherForecast.Domain.Common;

namespace WeatherForecast.Infrastructure.Data
{
    public class WeatherForecastMaterializationInterceptor : IMaterializationInterceptor
    {
        public object InitializedInstance(MaterializationInterceptionData materializationData, object instance)
        {
            if (instance is Domain.Entities.WeatherForecast weatherForecast)
            {
                int i = Math.Max(0, Math.Min(Common.Constants.Summaries.Length - 1, (int)Math.Ceiling((double)(weatherForecast.Temperature + 60) / 12)));
                weatherForecast.Summary = Common.Constants.Summaries[i];
            }

            return instance;
        }
    }
}
