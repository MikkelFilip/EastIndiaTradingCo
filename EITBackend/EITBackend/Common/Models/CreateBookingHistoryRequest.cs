using System.ComponentModel.DataAnnotations;

namespace EITBackend.Common.Models
{
    public class CreateBookingHistoryRequest
    {

        public CreateBookingHistoryRequest(BookingHistory bookingHistory)
        {
            BookingHistory = bookingHistory;
        }


        [Required]
        public BookingHistory BookingHistory { get; set; }
    }
}
