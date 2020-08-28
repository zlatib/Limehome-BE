using System;
using System.Reflection.Metadata.Ecma335;

namespace HotelsApp.Core.Entities
{
    /// <summary>
    /// Booking entity
    /// </summary>
    public class Booking
    {
        public int BookingId { get; set; }

        public string PropertyId { get; set; }

        public DateTime BookDate { get; set; }

        public int Nights { get; set; }

        public double PricePerNight { get; set; }

        public bool Canceled { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        //virtuals
        public Property Property { get; set; }

    }
}
