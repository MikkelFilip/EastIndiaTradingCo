using System.ComponentModel.DataAnnotations;

namespace EITBackend.Common.Models
{
    public class ContentType
    {

        /// <summary>
        /// Unique id of a ContentType
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Reference Id of a ContentType
        /// </summary>
        public String? ContentTypeReferenceId { get; set; }

        /// <summary>
        /// Name of a ContentType
        /// </summary>
        public String? Name { get; set; }
    }
}