using System;
using System.Collections.Generic;

namespace HotelsApp.Core.Entities
{
    /// <summary>
    /// Property entity
    /// </summary>
    public class Property
    {
        public Property()
        {
            Bookings = new HashSet<Booking>();
        }

        public string PropertyId { get; set; }

        public string PropertyName { get; set; }

        public string Country { get; set; }
        public string AddressInfo { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        //virtuals
        public ICollection<Booking> Bookings { get; set; }
    }
}