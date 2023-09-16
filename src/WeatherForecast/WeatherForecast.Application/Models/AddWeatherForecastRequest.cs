using System.ComponentModel.DataAnnotations;
using WeatherForecast.Domain.Validators;

namespace WeatherForecast.Application.Models
{
    public class AddWeatherForecastRequest
    {
        [Required]
        [FutureDate]
        public DateTime Date { get; set; }

        [Required]
        [Range(-60, 60)]
        public int Temperature { get; set; }
    }
}
