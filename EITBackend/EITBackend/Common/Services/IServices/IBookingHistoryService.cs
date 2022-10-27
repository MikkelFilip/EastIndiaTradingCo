using EITBackend.Common.DTOs;
using EITBackend.Common.Models;

namespace EITBackend.Common.Services.IServices
{
    /// <summary>
    /// Service to interact with transport operators.
    /// </summary>
    public interface IBookingHistoryService
    {
        public BookingHistory PostBookingHistory(BookingHistory bookingHistory);
    }

}
