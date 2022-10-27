using System.ComponentModel.DataAnnotations;

namespace EITBackend.Common.Models
{
    public class ConnectedCitiesSegment
    {
        /// <summary>
        /// Unique id of a ConnectedCitiesSegment
        /// </summary>
        [Required]
        [Key]
        public int ConnectedCitiesSegmentId { get; set; }

        /// <summary>
        /// Unique Id of the from city
        /// </summary>
        public int FromCityId { get; set; }

        /// <summary>
        /// Unique Id of the to city
        /// </summary>
        public int ToCityId { get; set; }

        /// <summary>
        /// Number of segments
        /// </summary>
        public int Segments { get; set; }

    }
}
