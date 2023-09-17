using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Application.Interfaces;
using WeatherForecast.Application.Models;

namespace WeatherForecast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpPost]
        public async Task<ActionResult> AddWeatherForecast(AddWeatherForecastRequest request)
        {
            var id = await _weatherService.AddWeatherForecastAsync(request);

            return CreatedAtAction(nameof(GetWeatherForecast), new { Id = id }, null);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecastDto>> GetWeatherForecast(int id)
        {
            var weatherForecast = await _weatherService.GetWeatherForecastAsync(id);

            if (weatherForecast == null)
            {
                return NotFound();
            }

            return weatherForecast;
        }

        [HttpGet("Weekly")]
        public async Task<ActionResult<IList<WeatherForecastDto>>> GetWeeklyWeatherForecast()
        {
            var forecasts = await _weatherService.GetWeeklyWeatherForecastAsync();

            return Ok(forecasts);
        }
    }
}
