using EITBackend.Common.Models;

namespace EITBackend.Common.Adapters.IAdapters
{
    public interface IBookingHistoryAdapter
    {
        BookingHistory PostBookingHistory(BookingHistory booking);
    }
}