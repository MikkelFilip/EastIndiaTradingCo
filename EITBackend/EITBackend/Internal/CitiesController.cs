using EITBackend.Common.Models;
using Microsoft.AspNetCore.Mvc;
using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using QuikGraph.Algorithms.ShortestPath;

namespace EITBackend.Internal
{
    [ApiController]
    [Route("Cities")]
    public class CitiesController : ControllerBase
    {


        private readonly ILogger<CitiesController> _logger;
        private DataContext context;
        public CitiesController(ILogger<CitiesController> logger, DataContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet("/GetCities")]
        public IEnumerable<City> GetCities()
        {
            return context.cities.ToList();

        }

        [HttpGet("/Test")]
        public ActionResult Test()
        {
            var edges = new[] { new Edge<int>(1, 2), new Edge<int>(2, 3), new Edge<int>(2, 4), new Edge<int>(4, 1), new Edge<int>(3, 5), new Edge<int>(5, 1) };
            var graph = edges.ToAdjacencyGraph<int, Edge<int>>();
            var fw = new FloydWarshallAllShortestPathAlgorithm<int, Edge<int>>(graph, (edge) => 2);

            fw.Compute();

            // Get interesting paths
            if (fw.TryGetPath(1, 5, out IEnumerable<Edge<int>> path))
            {
                foreach (Edge<int> edge in path)
                {
                    Console.WriteLine(edge);
                }
            }

            //// Create algorithm
            //var dfs = new DepthFirstSearchAlgorithm<int, Edge<int>>(graph);
            //// Do the search
            //dfs.Compute();

            //var observer = new VertexPredecessorRecorderObserver<int, Edge<int>>();
            //using (observer.Attach(dfs)) // Attach/detach to DFS events
            //{
            //    dfs.Compute();
            //};

            //observer.TryGetPath(1, 5, out IEnumerable<Edge<int>> path);
            return Ok();

        }
    }
}
