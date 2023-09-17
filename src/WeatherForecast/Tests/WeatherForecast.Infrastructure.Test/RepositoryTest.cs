using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Core;
using WeatherForecast.Infrastructure.Data;
using WeatherForecast.Infrastructure.Repositories;

namespace WeatherForecast.Infrastructure.Test
{
    public class RepositoryTest
    {
        private readonly WeatherForecastDbContext _dbContext;
        IWeatherRepository _repository;

        public RepositoryTest()
        {
            var options = new DbContextOptionsBuilder<WeatherForecastDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
            _dbContext = new WeatherForecastDbContext(options);
            _repository = new WeatherRepository(_dbContext);
        }

        [Fact]
        public async void Given_ValidData_When_AddAsync_Then_SuccessfullyInsertData()
        {
            // Arrange
            var weatherForecast = new Domain.Entities.WeatherForecast
            {
                Date = DateTime.Now,
                Temperature = 0
            };

            // Act
            var result = await _dbContext.AddAsync(weatherForecast);
            await _dbContext.SaveChangesAsync();

            // Assert
            var addedEntity = _dbContext.WeatherForecasts.First(p => p.Id == result.Entity.Id);
            Assert.Equal(result.Entity, addedEntity);
        }

        [Fact]
        public async void Given_ExistingId_When_AddAsync_Then_FailToInsertData()
        {
            // Arrange
            var entity1 = new Domain.Entities.WeatherForecast
            {
                Date = DateTime.Now,
                Temperature = 60
            };

            var entity2 = new Domain.Entities.WeatherForecast
            {
                Date = DateTime.Now,
                Temperature = 60
            };

            // Act
            await _dbContext.AddAsync(entity1);
            await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.Clear();

            entity2.Id = entity1.Id;
            await _dbContext.AddAsync(entity2);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentException>(async () => await _dbContext.SaveChangesAsync());
        }

        [Fact]
        public async void Given_ValidData_When_AddAsync_FromRepository_Then_SuccessfullyInsertData()
        {
            // Arrange
            var weatherForecast = new Domain.Entities.WeatherForecast
            {
                Date = DateTime.Now,
                Temperature = 0
            };

            // Act
            var result = await _repository.AddAsync(weatherForecast);
            await _repository.SaveChangesAsync();

            // Assert
            var addedEntity = await _repository.GetByIdAsync(result.Id);
            Assert.Equal(result, addedEntity);
        }

        [Fact]
        public async void Given_ExistingId_When_AddAsync_FromRepository_Then_FailToInsertData()
        {
            // Arrange
            var entity1 = new Domain.Entities.WeatherForecast
            {
                Date = DateTime.Now,
                Temperature = 60
            };

            var entity2 = new Domain.Entities.WeatherForecast
            {
                Date = DateTime.Now,
                Temperature = 60
            };

            // Act
            entity1 = await _repository.AddAsync(entity1);
            await _repository.SaveChangesAsync();
            entity2.Id = entity1.Id;

            // Assert
            await Assert.ThrowsAnyAsync<InvalidOperationException>(async () => await _repository.AddAsync(entity2));
        }
    }
}