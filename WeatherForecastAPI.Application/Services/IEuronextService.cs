using WeatherForecastAPI.Domain.Entities;

namespace WeatherForecastAPI.Application.Services
{
    public interface IEuronextService
    {
        Task<List<WeatherForecastDisplay>> GetWeekAsync(DateOnly date);
        Task<WeatherForecastDisplay> GetByDateAsync(DateOnly date);
        Task<WeatherForecast> CreateAsync(WeatherForecast weatherForecast);
        Task<int> UpdateAsync(DateOnly date, WeatherForecast weatherForecast);
        Task<int> DeleteAsync(DateOnly date);
    }
}
