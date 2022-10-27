using EITBackend.Common.Models;

namespace EITBackend.Common.DTOs
{
    public class MostUsedRoute
    {
        public int NumberOfRoutes { get; set; }

        public City FromCity { get; set; } = null!;

        public City ToCity { get; set; } = null!;
    }
}
