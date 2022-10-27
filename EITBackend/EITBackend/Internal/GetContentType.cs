using EITBackend.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace EITBackend.Internal
{
    [ApiController]
    [Route("[controller]")]
    public class GetContentTypeController : ControllerBase
    {

        private readonly ILogger<GetContentTypeController> _logger;
        private DataContext context;
        public GetContentTypeController(ILogger<GetContentTypeController> logger, DataContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet(Name = "GetContentType")]
        public IEnumerable<ContentType> Get()
        {
            return context.contentTypes.ToList();

        }
    }
}
