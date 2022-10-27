using EITBackend.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace EITBackend.Internal
{
    [ApiController]
    [Route("[controller]")]
    public class GetConnectedCitiesController : ControllerBase
    {

        private readonly ILogger<GetConnectedCitiesController> _logger;
        private DataContext context;
        public GetConnectedCitiesController(ILogger<GetConnectedCitiesController> logger, DataContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet(Name = "GetConnectedCities")]
        public IEnumerable<ConnectedCitiesSegments> Get()
        {
            return context.connectedCitiesSegments.ToList();

        }
    }
}
