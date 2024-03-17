using System.ComponentModel.DataAnnotations;

namespace WeatherForecastAPI.Domain.Entities
{
    public class WeatherForecast
    {
        [Required, Key]
        public DateOnly Date { get; set; }

        [Required]
        public int TemperatureC { get; set; }
    }
}
