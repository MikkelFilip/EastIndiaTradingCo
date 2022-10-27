using EITBackend.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace EITBackend.Internal
{
    [ApiController]
    [Route("[controller]")]
    public class GetCitiesController : ControllerBase
    {


        private readonly ILogger<GetCitiesController> _logger;
        private DataContext context;
        public GetCitiesController(ILogger<GetCitiesController> logger, DataContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet(Name = "GetCities")]
        public IEnumerable<City> Get()
        {
            return context.cities.ToList();

        }
    }
}
