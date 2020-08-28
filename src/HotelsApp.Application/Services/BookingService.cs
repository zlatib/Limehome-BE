namespace HotelsApp.Application.Services
{
    using HotelsApp.Core.Contracts.Repositories;
    using HotelsApp.Core.Contracts.Services;
    using HotelsApp.Core.Models;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Booking Service
    /// </summary>
    public class BookingService : IBookingService
    {
        private IBookingsRepository bookingRepository;
        private IPropertiesRepository propertiesRepository;

        //ctor
        public BookingService(IBookingsRepository bookingRepository, IPropertiesRepository propertiesRepository)
        {
            this.bookingRepository = bookingRepository;
            this.propertiesRepository = propertiesRepository;
        }

        /// <summary>
        /// Add new Property
        /// </summary>
        /// <param name="property"><see cref="PropertyModel"/></param>
        /// <returns></returns>
        public PropertyModel AddProperty(PropertyModel property)
        {
            return this.propertiesRepository.AddProperty(property);
        }

        /// <summary>
        /// Get all bookings per property
        /// </summary>
        /// <param name="propertyId">property id</param>
        /// <returns></returns>
        public List<BookingModel> GetBookings(string propertyId)
        {
            return this.bookingRepository.GetBookings(propertyId);
        }

        /// <summary>
        /// Get property model by id
        /// </summary>
        /// <param name="propertyId">Property Id</param>
        /// <returns></returns>
        public PropertyModel GetProperty(string propertyId)
        {
            return this.propertiesRepository.GetProperty(propertyId);
        }

        /// <summary>
        /// Create new booking
        /// </summary>
        /// <param name="booking"><see cref="BookingModel"/></param>
        /// <returns></returns>
        public BookingModel NewBooking(BookingModel booking)
        {
            return this.bookingRepository.AddBooking(booking);
        }
    }
}