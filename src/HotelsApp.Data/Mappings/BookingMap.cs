using HotelsApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelsApp.Data.Mappings
{
    /// <summary>
    /// Booking Map
    /// </summary>
    public class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(c => c.BookingId);
            builder.Property(c => c.BookingId).HasColumnName("BookingId");

            builder.HasOne(c => c.Property)
                .WithMany(d => d.Bookings)
                .IsRequired(true)
                .HasForeignKey(u => u.PropertyId);
        }
    }
}
