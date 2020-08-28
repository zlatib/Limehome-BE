using HotelsApp.Core.Contracts.Repositories;
using HotelsApp.Core.Entities;
using HotelsApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace HotelsApp.Data.Repository
{
    public class PropertiesRepository : IPropertiesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PropertiesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteProperty(string propertyId)
        {
            var foundRecord = _dbContext.Properties.FirstOrDefault(p => p.PropertyId == propertyId);
            if (foundRecord == null)
            {
                return;
            }

            // Be sure to remove assignements
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Bookings] WHERE [PropertyId]={0}", propertyId);

            _dbContext.Properties.Remove(foundRecord);
            _dbContext.SaveChanges();
        }

        public List<PropertyModel> GetProperties(int pageNo = 0, int pageSize = 25)
        {
            var query = _dbContext.Properties.AsQueryable();

            //var allItems = query.AsNoTracking();
            //int totalCount = allItems.Count();

            var items = query.AsNoTracking()
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .Select(u => new PropertyModel
                {
                    PropertyId = u.PropertyId,
                    PropertyName = u.PropertyName,
                    City = u.City,
                    AddressInfo = u.AddressInfo,
                    Country = u.Country,
                    Phone = u.Phone,
                })
                .ToList();

            return items;
        }

        public PropertyModel GetProperty(string propertyId, bool includeBookings = false)
        {
            var entity = _dbContext.Properties
                .Include(x => x.Bookings)
                .FirstOrDefault(c => c.PropertyId == propertyId);

            if (entity == null) return null;

            return MapToModel(entity);
        }

        public PropertyModel AddProperty(PropertyModel hotel)
        {
            var addedEntity = _dbContext.Properties.Add(new Property
            {
                PropertyId = hotel.PropertyId,
                PropertyName = hotel.PropertyName,
                Country = hotel.Country,
                City = hotel.City,
                AddressInfo = hotel.AddressInfo,
                Phone = hotel.Phone,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }); ;

            _dbContext.SaveChanges();
            return MapToModel(addedEntity.Entity);
        }

        public PropertyModel UpdateProperty(PropertyModel hotel)
        {
            var foundRecord = _dbContext.Properties.FirstOrDefault(p => p.PropertyId == hotel.PropertyId);
            if (foundRecord != null)
            {
                foundRecord.PropertyId = hotel.PropertyId;
                foundRecord.PropertyName = hotel.PropertyName;
                foundRecord.Country = hotel.Country;
                foundRecord.City = hotel.City;
                foundRecord.AddressInfo = hotel.AddressInfo;
                foundRecord.Phone = hotel.Phone;

                foundRecord.UpdatedAt = DateTime.UtcNow;

                _dbContext.SaveChanges();

                return MapToModel(foundRecord);
            }

            return null;
        }

        // Private
        private static PropertyModel MapToModel(Property entity)
        {
            if (entity == null) return null;

            var model = new PropertyModel()
            {
                PropertyId = entity.PropertyId,
                PropertyName = entity.PropertyName,
                City = entity.City,
                AddressInfo = entity.AddressInfo,
                Country = entity.Country,
                Phone = entity.Phone,
                Bookings = new List<BookingModel>()
            };

            if(entity.Bookings != null && entity.Bookings.Any())
            {
                foreach(var booking in entity.Bookings)
                {
                    model.Bookings.Add(new BookingModel() { 
                        Id = booking.BookingId,
                        PropertyId = booking.PropertyId,
                        BookDate = booking.BookDate,
                        Nights = booking.Nights,
                        PricePerNight = booking.PricePerNight
                    });
                }
            }

            return model;
        }
    }
}
