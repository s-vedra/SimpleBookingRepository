using Microsoft.Extensions.DependencyInjection;
using SimpleBookingSystem_DAL.Abstraction;
using SimpleBookingSystem_DAL.Implementation;
using SimpleBookingSystem_Services.Abstraction;
using SimpleBookingSystem_Services.Implementation;
using SimpleBookingSystem_Services.Queries;

namespace SimpleBookingSystem_Utilities
{
    public static class ServicesUtility
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection service)
        {
            service.AddScoped<IResourceRepository, ResourceRepository>();
            service.AddScoped<IResourceService, ResourceService>();
            service.AddScoped<IBookingRepository, BookingRepository>();
            service.AddScoped<IBookingService, BookingService>();
            service.AddScoped<IDateRangeRepository, DateRangeRepository>();
            service.AddScoped<IBookingQueryService, BookingQueryService>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserService, UserService>();
            return service;
        }
    }
}
