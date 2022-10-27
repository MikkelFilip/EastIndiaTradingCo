using Microsoft.AspNetCore.Mvc;

namespace EITBackend.External
{
    [ApiController]
    [Route("/api/external/EIT/[controller]")]
    public class ExternalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
