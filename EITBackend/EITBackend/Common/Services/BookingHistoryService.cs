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
        public BookingHistoryService(IBookingHistoryAdapter bookingHistoryAdapter, IEmailService emailService, ILogger<BookingHistoryService> logger)
        {
            BookingHistoryAdapter = bookingHistoryAdapter;
            EmailService = emailService;
            Logger = logger;
            Logger.LogInformation($"{nameof(BookingHistoryService)} created");
        }

        private IBookingHistoryAdapter BookingHistoryAdapter { get; }

        private ILogger<BookingHistoryService> Logger { get; }

        private IEmailService EmailService { get; }

        public List<MostUsedRoute> GetMostUsedRoutes()
        {
            return BookingHistoryAdapter.GetMostUsedRoutes();
        }

        public BookingHistory PostBookingHistory(BookingHistory bookingHistory)
        {
            BookingHistory returnedBooking =  BookingHistoryAdapter.PostBookingHistory(bookingHistory);
            EmailService.sendEmail(returnedBooking.CustomerEmail, "EIT Booking Confirmation: #" + returnedBooking.BookingId, returnedBooking.ToString());
            return returnedBooking;
        }
    }
}
