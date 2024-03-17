using Microsoft.EntityFrameworkCore;
using WeatherForecastAPI.Domain.Entities;

namespace WeatherForecastAPI.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WeatherForecast>().HasKey(w => w.Date);
            builder.Entity<WeatherForecast>().ToTable("WeatherForecasts");
        }
    }
}
