using System;
using System.Collections.Generic;
using System.Text;

namespace HotelsApp.Core.Models
{
    public class PropertyModel
    {
        public string PropertyId { get; set; }

        public string PropertyName { get; set; }
        public string Country { get; set; }
        public string AddressInfo { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public List<BookingModel> Bookings { get; set; }
    }
}
