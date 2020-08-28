using System;
using System.Collections.Generic;
using System.Text;

namespace HotelsApp.Core.Models
{
    public class BookingModel
    {
        public int Id { get; set; }

        public string PropertyId { get; set; }

        public DateTime BookDate { get; set; }

        public int Nights { get; set; }
        public double PricePerNight { get; set; }
        public bool Canceled { get; set; }

    }
}
