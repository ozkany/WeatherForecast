using System.ComponentModel.DataAnnotations;
using WeatherForecast.Domain.Validators;

namespace WeatherForecast.Application.Models
{
    public record WeatherForecastDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Temperature { get; set; }

        public string Summary { get; set; }
    }
}
