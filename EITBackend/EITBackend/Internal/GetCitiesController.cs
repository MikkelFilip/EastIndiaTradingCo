using EITBackend.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace EITBackend.Internal
{
    [ApiController]
    [Route("[controller]")]
    public class GetCitiesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<GetCitiesController> _logger;
        private DataContext context;
        public GetCitiesController(ILogger<GetCitiesController> logger, DataContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet(Name = "GetCities")]
        public IEnumerable<Cities> Get()
        {
            return context.cities.ToList();

        }
    }
}
