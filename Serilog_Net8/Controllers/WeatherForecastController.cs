using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Serilog_Net8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        { 
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

          try
            {
                _logger.LogInformation("APi hit now");

             
                var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();

                _logger.LogInformation($"Weather forecasts: {result}");
                Log.Information("The Result Are : {@result}", result);
                return result;
            }
            catch(Exception e)
            {
                Log.Error(e, "Unable to get forcast");
            }

            return Enumerable.Empty<WeatherForecast>();
        }
    }
}
