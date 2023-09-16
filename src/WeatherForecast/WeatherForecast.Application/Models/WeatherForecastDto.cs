using System.ComponentModel.DataAnnotations;
using WeatherForecast.Domain.Validators;

namespace WeatherForecast.Application.Models
{
    public class WeatherForecastDto
    {
        public DateTime Date { get; set; }

        public int Temperature { get; set; }

        public string Summary { get; set; }
    }
}
