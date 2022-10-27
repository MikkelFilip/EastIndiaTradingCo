using EITBackend.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace EITBackend.Internal
{
    [ApiController]
    [Route("Cities")]
    public class CitiesController : ControllerBase
    {


        private readonly ILogger<CitiesController> _logger;
        private DataContext context;
        public CitiesController(ILogger<CitiesController> logger, DataContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet("/GetCities")]
        public IEnumerable<City> GetCities()
        {
            return context.cities.ToList();

        }
    }
}
