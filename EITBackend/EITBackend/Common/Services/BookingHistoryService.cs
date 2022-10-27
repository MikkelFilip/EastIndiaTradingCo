using EITBackend.Common.Adapters.IAdapters;
using EITBackend.Common.DTOs;
using EITBackend.Common.Models;
using EITBackend.Common.Services.IServices;

namespace EITBackend.Common.Services
{
    public class BookingHistoryService : IBookingHistoryService
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="TransportOperatorService"/> class.
        /// </summary>
        /// <param name="transportOperatorAdapter">TransportOperator Adapter for connecting Drip.</param>
        /// <param name="logger">Logger.</param>
        public BookingHistoryService(IBookingHistoryAdapter bookingHistoryAdapter, ILogger<BookingHistoryService> logger)
        {
            BookingHistoryAdapter = bookingHistoryAdapter;
            Logger = logger;
            Logger.LogInformation($"{nameof(BookingHistoryService)} created");
        }

        private IBookingHistoryAdapter BookingHistoryAdapter { get; }

        private ILogger<BookingHistoryService> Logger { get; }

        public BookingHistory PostBookingHistory(BookingHistory bookingHistory)
        {
            return BookingHistoryAdapter.PostBookingHistory(bookingHistory);

        }
    }
}
