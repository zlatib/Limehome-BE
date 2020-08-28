namespace HotelsApp.Core.Contracts.Repositories
{
    using HotelsApp.Core.Models;
    using System;
    using System.Collections.Generic;

    public interface IBookingRepository
    {
        BookingModel AddBooking(BookingModel bookingModel);

        List<BookingModel> GetBookings(string propertyId);
    }
}