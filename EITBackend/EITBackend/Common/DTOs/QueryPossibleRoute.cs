using EITBackend.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace EITBackend.Common.DTOs
{
    public class QueryPossibleRoute
    {
        [Required]
        public City From { get; set; } = null!;

        [Required]
        public City To { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public PackageType PackageType { get; set; }

        [Required]
        public double Weight { get; set; } = 0;
    }
}
