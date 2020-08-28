namespace HotelsApp.Core.Contracts.Services
{
    using HotelsApp.Core.Entities;
    using HotelsApp.Core.Models;
    using System;
    using System.Collections.Generic;

    public interface IBookingService
    {
        PropertyModel GetProperty(string propertyId);
        PropertyModel AddProperty(PropertyModel property);
        List<BookingModel> GetBookings(string propertyId);
        BookingModel NewBooking(BookingModel booking);
    }
}
