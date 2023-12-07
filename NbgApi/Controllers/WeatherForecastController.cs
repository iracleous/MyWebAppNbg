using Microsoft.AspNetCore.Mvc;
using NbgApi.Models;
using NbgApi.Services;

namespace NbgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForcastService _weatherForcastService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherForcastService weatherForcastService)
        {
            _logger = logger;
            _weatherForcastService = weatherForcastService;
        }


        [HttpGet]
        [Route("ping")]
        public string GetHello()
        {
            return "It is working";
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.Log(LogLevel.Information, "Display weather fcts");
            return _weatherForcastService.GetForecasts();
        }

        [HttpGet]
        [Route("/{cityName}")]
        public WeatherForecast GetOneForecast([FromRoute]string cityName)
        {
            _logger.Log(LogLevel.Information, $"Display weather of {cityName}");
            return _weatherForcastService.GetForecastByCity(cityName);
        }

        [HttpPost]
        public WeatherForecast CreateWeather(WeatherForecast weather)
        {
            _logger.Log(LogLevel.Information, $"Add weather of {weather.City}");
            return _weatherForcastService.CreateForecast(weather);
        }

        [HttpDelete]
        [Route("/{cityName}")]
        public bool DeleteForecast([FromRoute] string cityName)
        {
            _logger.Log(LogLevel.Information, $"Delete weather of {cityName}");
            return _weatherForcastService.DeleteForecast(cityName);
        }

        [HttpPut]
        public WeatherForecast UpdateForecast(WeatherForecast weather)
        {
            _logger.Log(LogLevel.Information, $"Update weather of {weather.City}");
            return _weatherForcastService.UpdateForecast(weather.City, weather.TemperatureC);
        }
    }
}
