using Microsoft.EntityFrameworkCore;
using WeatherForecastAPI.Application.Services;
using WeatherForecastAPI.Domain.Repository;
using WeatherForecastAPI.Infrastructure;
using WeatherForecastAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(conn));
builder.Services.AddControllers();

builder.Services.AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();
builder.Services.AddTransient<IEuronextService, EuronextService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
