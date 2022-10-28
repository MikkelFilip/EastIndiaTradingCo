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

        public List<PossibleRoute> GetPossibleRoutes(int fromCityId, int toCityId)
        {
            var connectedCitiesSegments = _adapter.GetAll();
            var edges = connectedCitiesSegments.Select(connecting => new Edge<int>(connecting.FromCityId, connecting.ToCityId));

            var graph = edges.ToBidirectionalGraph<int, Edge<int>>();
            var fw = new FloydWarshallAllShortestPathAlgorithm<int, Edge<int>>(graph, (edge) => findWeight(connectedCitiesSegments, edge));

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
                Duration = this.calculateTotalDurationOfPath(path),
                Price = 10,
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

        private int calculateTotalDurationOfPath(IEnumerable<Edge<int>> path)
        {
            int totalDuration = 0;
            foreach (Edge<int> edge in path)
            {
                int duration = _adapter.GetSegmentFromBothCitiesIds(edge.Source, edge.Target);
                totalDuration += duration * 12;
            }
            return totalDuration;
        }


    }
}
