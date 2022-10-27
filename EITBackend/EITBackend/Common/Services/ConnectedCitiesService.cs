using EITBackend.Common.Adapters.IAdapters;
using EITBackend.Common.DTOs;
using EITBackend.Common.Models;
using EITBackend.Common.Services.IServices;

namespace EITBackend.Common.Services
{
    public class ConnectedCitiesService : IConnectedCitiesService
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="TransportOperatorService"/> class.
        /// </summary>
        /// <param name="transportOperatorAdapter">TransportOperator Adapter for connecting Drip.</param>
        /// <param name="logger">Logger.</param>
        public ConnectedCitiesService(IConnectedCitiesSegmentAdapter connectedCitiesSegmentAdapter, ILogger<ConnectedCitiesService> logger)
        {
            ConnectedCitiesSegmentAdapter = connectedCitiesSegmentAdapter;
            Logger = logger;
            Logger.LogInformation($"{nameof(ConnectedCitiesService)} created");
        }

        private IConnectedCitiesSegmentAdapter ConnectedCitiesSegmentAdapter { get; }

        private ILogger<ConnectedCitiesService> Logger { get; }

        public GetConnectedCities GetConnectedCities(string cityName, int weight, string contentType, DateTime dateTime, string packageType)
        {
            IEnumerable<ConnectedCitiesSegment> connectedCitySegments = ConnectedCitiesSegmentAdapter.GetConnectedCitiesSegment(cityName);
            List<ConnectedCities> connectedCities = new List<ConnectedCities>();

            if (connectedCitySegments != null) {
                foreach (ConnectedCitiesSegment connectedCitySegment in connectedCitySegments)
                {
                    int duration = connectedCitySegment.Segments * 12;
                    Double price = this.CalculatePrice(connectedCitySegment.Segments, dateTime);

                    ConnectedCities connectedCity = new()
                    {
                        CityName = "Cairo",
                        Price = price,
                        Duration = duration
                    };

                    connectedCities.Add(connectedCity);
                }
            }

            GetConnectedCities getConnectedCities = new()
            {
                Provider = "East Indian Trading Co",
                ConnectedCities = connectedCities,
            };
            return getConnectedCities;
        }


        private Double CalculatePrice(int segment, DateTime dateTime)
        {
            int initialPrice = 5;
            double price = 0.0;
            if (5 < dateTime.Month && dateTime.Month < 10)
            {
                initialPrice = 8;
            }

            price = initialPrice * segment;

            //TODO:
            return price;
        }
    }
}
