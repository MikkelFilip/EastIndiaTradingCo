using System.ComponentModel.DataAnnotations;

namespace EITBackend.Common.Models
{
    public class Cities
    {

        /// <summary>
        /// Unique id of a Cities
        /// </summary>
        [Required]
        [Key]
        public int CityId { get; set; }

        /// <summary>
        /// The Name of the Cities
        /// </summary>
        [Required]
        public string? Name { get; set; }
    }
}