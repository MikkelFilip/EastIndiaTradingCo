using System.ComponentModel.DataAnnotations;

namespace EITBackend.Common.Models
{
    public class ConnectedCities
    {

        /// <summary>
        /// Unique id of a Cities
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// One of the cities with is a part of the tavel
        /// </summary>
        [Required]
        public int FirstCity { get; set; }

        /// <summary>
        /// The other cities with is a part of the tavel
        /// </summary>
        [Required]
        public int SecondCity { get; set; }

        /// <summary>
        /// The number of segments between to cities
        /// </summary>
        [Required]
        public int segments { get; set; }
    }
}