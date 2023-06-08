using Microsoft.AspNetCore.Mvc;

namespace RestWebApi.Controllers
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

        [HttpGet]
        [Route("GetWeatherForcast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public string ReturnString(int id, string name)
        {
            return name + id.ToString();
        }

        [HttpGet("{id}")]
        public async Task<string> GetFromId(int id,[FromQuery]string name)
        {
            return "Id: " + id + " name: " + name;
        }

        [HttpPost()]
        [Route("GetFromBody")]
        public async Task<string> Save(int id, [FromBody] string name)
        {
            return "Id: " + id + " name: " + name;
        }


    }
}