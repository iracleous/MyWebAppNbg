using NbgApi.Models;
using NbgApi.Services;

namespace NbgApi.Repositories
{
    public interface IWeatherRepository
    {
        //CRUD
        public WeatherForecast? CreateWeatherForecast(WeatherForecast weather);
        public WeatherForecast? ReadWeatherForecast(string city);
        public List<WeatherForecast> ReadWeatherForecast();
        public WeatherForecast? UpdateWeatherForecast(string city, int newTemp);
        public bool DeleteWeatherForecast(string city);
     }
}
