namespace HotelsApp.Data
{
    using HotelsApp.Core.Entities;
    using HotelsApp.Data.Mappings;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PropertyMap());
            modelBuilder.ApplyConfiguration(new BookingMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}