﻿using System.ComponentModel.DataAnnotations;

namespace EITBackend.Common.Models
{
    public class BookingHistory
    {

        /// <summary>
        /// Unique id of a BookingHistory
        /// </summary>
        [Required]
        public Guid BookingId { get; set; }


        /// <summary>
        /// Unique id of the From City
        /// </summary>
        [Required]
        public Guid FromCityId { get; set; }


        /// <summary>
        /// Unique id of the To City
        /// </summary>
        [Required]
        public Guid ToCityId { get; set; }

        /// <summary>
        /// Sending date
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Duration of the booking
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// Total Price of the booking
        /// </summary>
        public Double? Price { get; set; }

        /// <summary>
        /// Unique Id of the content type belong to the ooking
        /// </summary>
        public Guid ContentTypeId {get; set;}

        /// <summary>
        /// Name of the customer
        /// </summary>
        public string? CustomerName { get; set; }

        /// <summary>
        /// Email of the customer
        /// </summary>
        public string? CustomerEmail { get; set; }
    }
}