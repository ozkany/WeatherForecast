﻿using System.ComponentModel.DataAnnotations;
using WeatherForecast.Domain.Validators;

namespace WeatherForecast.Domain.Entities
{
    public class WeatherForecast : BaseEntity
    {
        [Required]
        [FutureDate]
        public DateTime Date { get; set; }

        [Required]
        [Range(-60, 60)]
        public int Temperature { get; set; }
    }
}
