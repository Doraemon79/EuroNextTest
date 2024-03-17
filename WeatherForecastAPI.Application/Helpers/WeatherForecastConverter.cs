namespace WeatherForecastAPI.Application.Helpers
{
    public static class WeatherForecastConverter
    {
        private static readonly IDictionary<string, (int, int)> _weatherConditions = new Dictionary<string, (int, int)>() {
            {"Freezing", (-40, -21) },
            {"Bracing", (-20, -10) },
            {"Chilli", (-9, 10) },
            {"Cool", (15, 15) },
            {"Mild", (16, 20) },
            {"Warm", (21, 25) },
            {"Balmy", (26, 30) },
            {"Hot", (31, 35) },
            {"Sweltering", (36, 40) },
            {"Scorching", (41, 50) },
        };

        public static string GetWeatherCondition(int temperature)
        {
            var weatherCondtion = "Unknown";
            foreach (KeyValuePair<string, (int, int)> entry in _weatherConditions)
            {
                if (temperature >= entry.Value.Item1 && temperature <= entry.Value.Item2)
                {
                    weatherCondtion = entry.Key;
                    break;
                }
            }
            return weatherCondtion;
        }
    }
}
