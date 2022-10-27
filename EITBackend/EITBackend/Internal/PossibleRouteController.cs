using EITBackend.Common.Models;
using EITBackend.Common.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using QuikGraph.Algorithms.ShortestPath;

namespace EITBackend.Internal
{
    [ApiController]
    [Route("PossibleRoutes")]
    public class PossibleRouteController : ControllerBase
    {
        private readonly ILogger<CitiesController> _logger;
        private readonly IPossibleRouteService _possibleRouteService;
        public PossibleRouteController(ILogger<CitiesController> logger, IPossibleRouteService possibleRouteService)
        {
            _logger = logger;
            this._possibleRouteService = possibleRouteService;
        }

        [HttpGet()]
        public IActionResult GetPossibleRoutes(int fromCityId, int toCityId)
        {
            var result = _possibleRouteService.GetPossibleRoutes(fromCityId, toCityId);
            return Ok(result);

        }
    }
}
