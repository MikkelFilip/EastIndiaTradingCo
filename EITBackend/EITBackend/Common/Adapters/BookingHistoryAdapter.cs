using EITBackend.Common.Adapters.IAdapters;
using EITBackend.Common.Models;
using System.Collections.Generic;
using System;
using System.Net.Mime;
using EITBackend.Common.DTOs;

namespace EITBackend.Common.Adapters
{
    public class BookingHistoryAdapter : IBookingHistoryAdapter
    {
        private DataContext context;
        public BookingHistoryAdapter(DataContext context)
        {
            this.context = context;
        }

        public List<MostUsedRoute> GetMostUsedRoutes()
        {
            var cities = context.cities.ToList();
            return context.bookingHistory
                .GroupBy(booking => new { From = booking.FromCityId, To = booking.ToCityId })
                .Select(group => new
                {
                    NumberOfRoutes = group.Count(),
                    FromCity = group.Key.From,
                    ToCity = group.Key.To
                })
                .OrderByDescending(obj => obj.NumberOfRoutes)
                .Take(5)
                .ToList()
                .Select(obj => new MostUsedRoute()
                {
                    NumberOfRoutes = obj.NumberOfRoutes,
                    FromCity = cities.Find(city => city.CityId == obj.FromCity)!,
                    ToCity = cities.Find(city => city.CityId == obj.ToCity)!
                })
                .ToList();
        }

        public BookingHistory PostBookingHistory(BookingHistory bookingHistory)
        {
            context.bookingHistory.Add(bookingHistory);
            context.SaveChanges();
            return bookingHistory;
        }
    }
}
