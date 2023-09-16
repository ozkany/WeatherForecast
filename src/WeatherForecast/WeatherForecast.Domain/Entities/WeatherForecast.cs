using System.ComponentModel.DataAnnotations;
using WeatherForecast.Domain.Validators;

namespace WeatherForecast.Domain.Entities
{
    public class WeatherForecast : BaseEntity
    {
        [FutureDate]
        public DateTime Date { get; set; }

        [Range(-60, 60)]
        public int Temperature { get; set; }
    }
}
