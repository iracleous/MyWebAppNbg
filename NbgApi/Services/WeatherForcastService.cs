using NbgApi.Models;
using NbgApi.Repositories;

namespace NbgApi.Services
{
    public class WeatherForcastService: IWeatherForcastService
    {

        private readonly IWeatherRepository _weatherRepository = new WeatherRepository();

        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecast CreateForecast(WeatherForecast weatherForecast)
        {
            _weatherRepository.CreateWeatherForecast(weatherForecast);
            return weatherForecast;
        }

        public bool DeleteForecast(string city)
        {
          return  _weatherRepository.DeleteWeatherForecast(city);
        }

        public WeatherForecast GetForecastByCity(string city)
        {
            return _weatherRepository.ReadWeatherForecast(city)?? new WeatherForecast();
        }

        public WeatherForecast GetForecastById(int id)
        {
            return new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                Summary = "",
                TemperatureC = id,
            };
        }

        public IEnumerable<WeatherForecast> GetForecasts()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public WeatherForecast UpdateForecast(string city, int temp)
        {
            WeatherForecast? weatherForecast = _weatherRepository.ReadWeatherForecast(city);
            if (weatherForecast != null)
            weatherForecast.TemperatureC = temp;
            return weatherForecast?? new WeatherForecast();
        }

        List<WeatherForecast> IWeatherForcastService.GetForecasts()
        {
            return _weatherRepository.ReadWeatherForecast();
        }
    }
}
