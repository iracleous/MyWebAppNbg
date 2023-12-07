using NbgApi.Models;

namespace NbgApi.Repositories
{

    public class WeatherRepository : IWeatherRepository
    {

        private static readonly Dictionary<string, WeatherForecast> _repository =
            new Dictionary<string, WeatherForecast>();

        public WeatherForecast? CreateWeatherForecast(WeatherForecast weather)
        {
            if (weather != null && weather.City!=null )
            _repository.Add(weather.City, weather);
            return weather;
        }

        public bool DeleteWeatherForecast(string city)
        {
            _repository.Remove(city);
            return true;
        }

        public WeatherForecast? ReadWeatherForecast(string city)
        {
            return _repository[city];
        }

        public List<WeatherForecast> ReadWeatherForecast()
        {
            return _repository.Values.ToList();
        }

        public WeatherForecast? UpdateWeatherForecast(string city, int newTemp)
        {
            WeatherForecast? weather = ReadWeatherForecast(city);
            if (weather != null)
            weather.TemperatureC = newTemp;
            return weather;
        }
    }
}
