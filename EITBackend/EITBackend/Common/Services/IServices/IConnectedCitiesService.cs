using EITBackend.Common.DTOs;

namespace EITBackend.Common.Services.IServices
{
    /// <summary>
    /// Service to interact with transport operators.
    /// </summary>
    public interface IConnectedCitiesService
    {
        public GetConnectedCities GetConnectedCities(string cityName, int weight, string contentType, DateTime dateTime, string packageType);
    }

}
