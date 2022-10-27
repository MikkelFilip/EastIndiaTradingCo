using EITBackend.Common.Models;

namespace EITBackend.Common.DTOs
{
    public class PossibleRoute
    {
        public City From { get; set; } = null!;

        public City To { get; set; } = null!;

        public int Duration { get; set; } = 0;

        public double Price { get; set; } = 0;

        public List<City> Cities { get; set; } = new();

        public List<string> Companies { get; set; } = new();
    }
}
