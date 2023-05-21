using Microsoft.EntityFrameworkCore;
using SimpleBookingSystem_DomainModels;

namespace SimpleBookingSystem_DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<DateRange> DateRanges { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedEntities();
        }
    }
}
