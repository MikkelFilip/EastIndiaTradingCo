using Microsoft.AspNetCore.Mvc;

namespace EITBackend.Internal
{
    [ApiController]
    [Route("[controller]")]
    public class GetContentTypeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<GetContentTypeController> _logger;

        public GetContentTypeController(ILogger<GetContentTypeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetContentType")]
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
    }
}
