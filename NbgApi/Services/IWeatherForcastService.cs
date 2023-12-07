using NbgApi.Models;

namespace NbgApi.Services
{
    public interface IWeatherForcastService
    {
 
        public WeatherForecast GetForecastByCity(string city);
        public List<WeatherForecast> GetForecasts();
        public WeatherForecast CreateForecast(WeatherForecast weatherForecast);
        public WeatherForecast UpdateForecast( string city, int temp);
        public bool DeleteForecast(string city);

    }
}
