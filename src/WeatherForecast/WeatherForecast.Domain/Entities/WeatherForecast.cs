using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeatherForecast.Domain.Validators;

namespace WeatherForecast.Domain.Entities
{
    public class WeatherForecast : BaseEntity
    {
        private DateTime _date;
        [Required]
        [FutureDate]
        public DateTime Date
        {
            get => _date;
            set => _date = value.Date;
        }

        [Required]
        [Range(-60, 60)]
        public int Temperature { get; set; }

        [NotMapped]
        public string Summary { get; set; }
    }
}
