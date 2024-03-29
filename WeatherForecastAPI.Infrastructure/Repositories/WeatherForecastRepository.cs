﻿using Microsoft.EntityFrameworkCore;
using WeatherForecastAPI.Domain.Entities;
using WeatherForecastAPI.Domain.Repository;

namespace WeatherForecastAPI.Infrastructure.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly AppDbContext _appDbContext;

        public WeatherForecastRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<WeatherForecast> CreateAsync(WeatherForecast weatherForecast)
        {
            await _appDbContext.WeatherForecasts.AddAsync(weatherForecast);
            await _appDbContext.SaveChangesAsync();
            return weatherForecast;
        }

        public async Task<int> DeleteAsync(DateOnly date)
        {
            return await _appDbContext.WeatherForecasts.Where(x => x.Date == date).ExecuteDeleteAsync();
        }

        public async Task<WeatherForecast> GetByDateAsync(DateOnly date)
        {
            return await _appDbContext.WeatherForecasts.FirstOrDefaultAsync(x => x.Date == date);
        }

        public async Task<List<WeatherForecast>> GetWeekAsync(DateOnly date)
        {
            return await _appDbContext.WeatherForecasts.Where(x => x.Date >= date && x.Date <= date.AddDays(6)).ToListAsync();
        }

        public async Task<int> UpdateAsync(DateOnly date, WeatherForecast weatherForecast)
        {
            return await _appDbContext.WeatherForecasts.Where(x => x.Date == date).ExecuteUpdateAsync(setters => setters
              .SetProperty(s => s.TemperatureC, weatherForecast.TemperatureC));
        }
    }
}
