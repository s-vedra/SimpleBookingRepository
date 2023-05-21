using Microsoft.EntityFrameworkCore;
using SimpleBookingSystem_DomainModels;

namespace SimpleBookingSystem_DAL
{
    public static class DbContextExtenstions
    {
        public static void SeedEntities(this ModelBuilder builder)
        {
            List<Resource> resources = new List<Resource>()
            {
                 new Resource()
                {
                    Id = 1,
                    Title = "Resource1",
                    Quantity = 10
                },
                 new Resource()
                 {
                     Id = 2,
                     Title = "Resource2",
                     Quantity = 5
                 },
                  new Resource()
                  {
                      Id = 3,
                      Title = "Resource3",
                      Quantity = 4
                  }
            };

            var user = new User()
            {
                Id = 1,
                Name = "Test",
                LastName = "Test",
                Email = "test@test.com"
            };

            builder.Entity<Resource>().ToTable("Resource").HasData(resources);
            builder.Entity<Booking>().ToTable("Booking");
            builder.Entity<DateRange>().ToTable("DateRange");
            builder.Entity<User>().ToTable("User").HasData(user);
        }
    }
}
