using HotelsApp.Core.Entities;
using HotelsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelsApp.Core.Contracts.Repositories
{
    public interface IBookingsRepository
    {
        List<BookingModel> GetBookings(string propertyId);
        BookingModel AddBooking(BookingModel booking);
        bool CancelBooking(int bookingId);
        void DeleteBooking(int bookingId);
    }
}
