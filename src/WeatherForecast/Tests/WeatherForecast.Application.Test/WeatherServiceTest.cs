using AutoMapper;
using Moq;
using WeatherForecast.Application.Models;
using WeatherForecast.Application.Services;
using WeatherForecast.Domain.Core;

namespace WeatherForecast.Application.Test
{
    public class WeatherServiceTest
    {
        private readonly WeatherService _weatherService;
        private readonly Mock<IWeatherRepository> _repository = new Mock<IWeatherRepository>();
        private readonly IMapper _mapper;

        public WeatherServiceTest()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<Mappings.MappingProfiles>());
            _mapper = mapperConfig.CreateMapper();
            _weatherService = new WeatherService(_repository.Object, _mapper);
        }

        [Fact]
        public async void Given_WithValidData_When_AddWeatherForecast_Then_SuccessfullyCreateWeatherForecast()
        {
            // Arrange
            var id = 1;
            var request = new AddWeatherForecastRequest()
            {
                Date = DateTime.Today,
                Temperature = 60
            };

            _repository.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.WeatherForecast>()))
                .ReturnsAsync(new Domain.Entities.WeatherForecast()
                {
                    Id = id
                });

            // Act
            var result = await _weatherService.AddWeatherForecastAsync(request);

            // Assert
            Assert.Equal(id, result);
        }

        [Fact]
        public async void Given_WithValidData_When_GetWeatherForecast_Then_SuccessfullyReturnWeatherForecast()
        {
            // Arrange
            var id = 1;
            var weatherForecastDto = new WeatherForecastDto()
            {
                Id = id,
                Date = DateTime.Today,
                Temperature = 60
            };

            _repository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Domain.Entities.WeatherForecast()
                {
                    Id = id,
                    Date= DateTime.Today,
                    Temperature = 60
                });

            // Act
            var result = await _weatherService.GetWeatherForecastAsync(id);

            // Assert
            Assert.Equal(result, weatherForecastDto);
        }
    }
}