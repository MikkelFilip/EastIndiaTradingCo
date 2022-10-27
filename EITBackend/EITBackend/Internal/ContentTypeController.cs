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
        public IEnumerable<int> Get()
        {
            return Enumerable.Range(1, 5)
            .ToArray();
        }
    }
}
