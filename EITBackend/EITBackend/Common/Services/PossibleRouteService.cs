using EITBackend.Common.Adapters.IAdapters;
using EITBackend.Common.DTOs;
using EITBackend.Common.Models;
using EITBackend.Common.Services.IServices;
using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.RankedShortestPath;
using QuikGraph.Algorithms.Search;
using QuikGraph.Algorithms.ShortestPath;

namespace EITBackend.Common.Services
{
    public class PossibleRouteService : IPossibleRouteService
    {
        private readonly IConnectedCitiesSegmentAdapter _adapter;
        private readonly ICityAdapter _cityAdapter;
        public PossibleRouteService(IConnectedCitiesSegmentAdapter adapter, ICityAdapter cityAdapter)
        {
            this._adapter = adapter;
            this._cityAdapter = cityAdapter;
        }

        public List<PossibleRoute> GetPossibleRoutes(QueryPossibleRoute query)
        {
            int fromCityId = query.From.CityId;
            int toCityId = query.To.CityId;

            var connectedCitiesSegments = _adapter.GetAll();
            var edges = connectedCitiesSegments.Select(connecting => new Edge<int>(connecting.FromCityId, connecting.ToCityId));

            var graph = edges.ToBidirectionalGraph<int, Edge<int>>();

            var algo = new HoffmanPavleyRankedShortestPathAlgorithm<int, Edge<int>>(graph, (edge) => findWeight(connectedCitiesSegments, edge));


            algo.Compute(fromCityId, toCityId);

            foreach (ICollection<Edge<int>> path in algo.ComputedShortestPaths)
            {
                Console.WriteLine("Path:");
                foreach (Edge<int> edge in path)
                {
                    Console.WriteLine(edge);
                }
            }

            var cities = _cityAdapter.GetAllCity().ToList();
            var fromCity = cities.Find(city => city.CityId == fromCityId);
            var toCity = cities.Find(city => city.CityId == toCityId);

            var result = algo.ComputedShortestPaths.Select(path => new PossibleRoute()
            {
                From = fromCity!,
                To = toCity!,
                Path = path,
                Duration = this.CalculateTotalDurationOfPath(path),
                Price = this.CalculateTotalPriceOfPath(path, query.Date, query.ContentType.Name),
                Companies = generateCompanies(path.Count())
            });

            return result.ToList();
        }

        private double findWeight(List<ConnectedCitiesSegment> connectedCitiesSegments, Edge<int> edge)
        {
            var connecting = connectedCitiesSegments
                .Find(connecting => connecting.FromCityId == edge.Source && connecting.ToCityId == edge.Target);

            return connecting!.Segments;
        }

        private List<string> generateCompanies(int number)
        {
            List<string> companies = new();
            for (int i = 0; i < number; i++)
            {
                companies.Add("EIT");
            }
            return companies;
        }

        private int CalculateTotalDurationOfPath(IEnumerable<Edge<int>> path)
        {
            int totalDuration = 0;
            foreach (Edge<int> edge in path)
            {
                int segment = _adapter.GetSegmentFromBothCitiesIds(edge.Source, edge.Target);
                totalDuration += segment * 12;
            }
            return totalDuration;
        }

        private Double CalculateTotalPriceOfPath(IEnumerable<Edge<int>> path, DateTime date, string contentType)
        {
            Double totalPrice = 0.0;
            foreach (Edge<int> edge in path)
            {
                int segment = _adapter.GetSegmentFromBothCitiesIds(edge.Source, edge.Target);
                totalPrice += this.CalculatePrice(segment, date, contentType);
            }
            return totalPrice;
        }

        private Double CalculatePrice(int segment, DateTime dateTime, string contentType)
        {
            contentType = contentType.ToLower();
            int initialPrice = 5;
            double price = 0.0;
            if (5 < dateTime.Month && dateTime.Month < 10)
            {
                initialPrice = 8;
            }

            price = initialPrice * segment;

            int extraChargesPercentage = 0;
            switch (contentType)
            {
                case "weapons":
                    extraChargesPercentage = 20;
                    break;
                case "live animals":
                    extraChargesPercentage = 25;
                    break;
                case "refrigerated goods":
                    extraChargesPercentage = 10;
                    break;
                default:
                    break;
            }

            price += (extraChargesPercentage * price) / 100;
            return price;
        }

    }
}
