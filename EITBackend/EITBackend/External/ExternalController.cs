using Microsoft.AspNetCore.Mvc;

namespace EITBackend.External
{
    [ApiController]
    [Route("/api/external/EIT/[controller]")]
    public class ExternalController : ControllerBase
    {

        private readonly ILogger<ExternalController> _logger;

        public ExternalController(ILogger<ExternalController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetConnectedCities")]
        public string GetConnectedCities()
        {
            return "it works";
        }
    }
}
