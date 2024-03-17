using WeatherForecastAPI.Application.Helpers;
using WeatherForecastAPI.Domain.Entities;
using WeatherForecastAPI.Domain.Repository;

namespace WeatherForecastAPI.Application.Services
{
    public class EuronextService : IEuronextService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        public EuronextService(IWeatherForecastRepository weatherForecastRepository)
        {

            _weatherForecastRepository = weatherForecastRepository;

        }

        public async Task<WeatherForecast> CreateAsync(WeatherForecast weatherForecast)
        {
            return await _weatherForecastRepository.CreateAsync(weatherForecast);
        }

        public async Task<int> DeleteAsync(DateOnly date)
        {
            return await _weatherForecastRepository.DeleteAsync(date);
        }

        public async Task<WeatherForecastDisplay> GetByDateAsync(DateOnly date)
        {

            var forecast = await _weatherForecastRepository.GetByDateAsync(date);
            WeatherForecastDisplay dateForecast = new WeatherForecastDisplay();
            if (forecast != null)
            {
                dateForecast = new WeatherForecastDisplay() { TemperatureC = forecast.TemperatureC, Date = forecast.Date, Description = WeatherForecastConverter.GetWeatherCondition(forecast.TemperatureC) };
            }


            return dateForecast;
        }

        public async Task<List<WeatherForecastDisplay>> GetWeekAsync(DateOnly date)
        {
            var week = await _weatherForecastRepository.GetWeekAsync(date);
            var weekForecast = new List<WeatherForecastDisplay>();
            for (int i = 0; i < week.Count; i++)
            {

                weekForecast.Add(new WeatherForecastDisplay() { TemperatureC = week[i].TemperatureC, Date = week[i].Date, Description = WeatherForecastConverter.GetWeatherCondition(week[i].TemperatureC) });
            }
            return weekForecast;
        }

        public async Task<int> UpdateAsync(DateOnly date, WeatherForecast weatherForecast)
        {
            var update = await (_weatherForecastRepository.UpdateAsync(date, weatherForecast));
            return update;
        }
    }
}
