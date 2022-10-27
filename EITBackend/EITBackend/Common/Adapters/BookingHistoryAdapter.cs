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

        public BookingHistory PostBookingHistory(BookingHistory bookingHistory)
        {
            context.bookingHistory.Add(bookingHistory);
            context.SaveChanges();
            return bookingHistory;
        }
    }
}
