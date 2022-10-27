using EITBackend.Common.Adapters.IAdapters;
using EITBackend.Common.Models;
using System.Collections.Generic;
using System;
using System.Net.Mime;

namespace EITBackend.Common.Adapters
{
    public class BookingHistoryAdapter : IBookingHistoryAdapter
    {
        private DataContext context;
        public BookingHistoryAdapter(DataContext context)
        {
            this.context = context;
        }

        public BookingHistory PostBookingHistory(BookingHistory booking)
        {
            BookingHistory bookingHistory = new BookingHistory() {
                BookingId = booking.BookingId,
                FromCityId = booking.FromCityId,
                ToCityId = booking.ToCityId,
                Date = booking.Date,
                Duration = booking.Duration,
                Price = booking.Price,
                ContentTypeId = booking.ContentTypeId,
                CustomerName = booking.CustomerName,
                CustomerEmail = booking.CustomerEmail,
            };
            context.bookingHistories.Add(bookingHistory);
            context.SaveChanges();
            return bookingHistory;
        }
    }
}
