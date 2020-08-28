namespace HotelsApp.Data.Repository
{
    using HotelsApp.Core.Contracts.Repositories;
    using HotelsApp.Core.Entities;
    using HotelsApp.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;


    public class BookingRepository : IBookingRepository
    {
        private ApplicationDbContext dbContext;

        public BookingRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public BookingModel AddBooking(BookingModel bookingModel)
        {
            Booking booking = new Booking()
            {
                BookingId = bookingModel.Id,
                PropertyId = bookingModel.PropertyId,
                BookDate = new DateTime(),
                Nights = 1,
                PricePerNight = 95.99
            };

            this.dbContext.Bookings.Add(booking);
            this.dbContext.SaveChanges();

            return bookingModel;
        }

        public List<BookingModel> GetBookings(Guid propId)
        {
            List<Booking> bookings = this.dbContext.Bookings.Where(x => x.PropertyId == propId)
                .ToList();
            List<BookingModel> result = new List<BookingModel>();

            foreach (var booking in bookings)
            {
                BookingModel bookingModel = new BookingModel()
                {
                    BookDate = booking.BookDate,
                    Nights = booking.Nights,
                    PricePerNight = booking.PricePerNight,
                    PropertyId = booking.PropertyId,
                };
                result.Add(bookingModel);
            }

            return result;
        }
    }
}