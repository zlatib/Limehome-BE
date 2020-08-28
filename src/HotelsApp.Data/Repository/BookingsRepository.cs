using HotelsApp.Core.Contracts.Repositories;
using HotelsApp.Core.Entities;
using HotelsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelsApp.Data.Repository
{
    public class BookingsRepository : IBookingsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookingModel AddBooking(BookingModel booking)
        {
            var addedEntity = _dbContext.Bookings.Add(new Booking
            {
                BookingId = booking.Id,
                PropertyId = booking.PropertyId,
                BookDate =booking.BookDate,
                Canceled = false,
                Nights = booking.Nights,
                PricePerNight = booking.PricePerNight,
               
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            _dbContext.SaveChanges();
            return MapToModel(addedEntity.Entity);
        }

        public bool CancelBooking(int bookingId)
        {
            var foundRecord = _dbContext.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (foundRecord != null)
            {
                foundRecord.Canceled = true;
                foundRecord.UpdatedAt = DateTime.UtcNow;

                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public void DeleteBooking(int bookingId)
        {
            var foundRecord = _dbContext.Bookings.FirstOrDefault(p => p.BookingId == bookingId);
            if (foundRecord == null)
            {
                return;
            }

            _dbContext.Bookings.Remove(foundRecord);
            _dbContext.SaveChanges();
        }

        public List<BookingModel> GetBookings(string propertyId)
        {
            var records = _dbContext.Bookings.Where(b => b.PropertyId == propertyId);
            var items = new List<BookingModel>();

            if(records != null && records.Any())
            {
                foreach(var record in records)
                {
                    items.Add(MapToModel(record));
                }
            }

            return items;
        }

        // Private
        private static BookingModel MapToModel(Booking entity)
        {
            if (entity == null) return null;

            var model = new BookingModel()
            {
                Id = entity.BookingId,
                PropertyId = entity.PropertyId,
                BookDate = entity.BookDate,
                Canceled = entity.Canceled,
                Nights = entity.Nights,
                PricePerNight = entity.PricePerNight                
            };

            return model;
        }
    }
}
