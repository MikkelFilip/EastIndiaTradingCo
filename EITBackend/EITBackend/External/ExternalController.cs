using EITBackend.Common.DTOs;
using EITBackend.Common.Models;
using EITBackend.Common.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EITBackend.External
{
    [ApiController]
    [Route("/api/GetConnectedCities")]
    public class ExternalController : Controller
    {

        private readonly ILogger<ExternalController> logger;
        private readonly IConnectedCitiesService connectedCitiesService;
        private string[] supportedContentType = { "live animals", "weapons", "refrigerated goods" };

        public ExternalController(IConnectedCitiesService connectedCitiesService, ILogger<ExternalController> logger)
        {
            this.connectedCitiesService = connectedCitiesService;
            this.logger = logger;
        }

        [HttpGet("{cityName}")]
        public ActionResult<GetConnectedCities> GetConnectedCitiesEndpoint(string cityName, [FromQuery(Name = "weight")] int weight, [FromQuery(Name = "contentType")] string contentType, [FromQuery(Name = "dateTime")] DateTime dateTime, [FromQuery(Name = "packageType")] string packageType)
        {
            if (supportedContentType.Contains(contentType.ToLower()))
            {
                return connectedCitiesService.GetConnectedCities(cityName, weight, contentType, dateTime, packageType);
            }

            return BadRequest();
        }
    }
}
