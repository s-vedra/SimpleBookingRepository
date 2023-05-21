using SimpleBookingSystem_DomainModels;

namespace SimpleBookingSystem_Services.Abstraction
{
    public interface IBookingQueryService
    {
        List<Booking> GetOverlappingBookings(DateRange dateRange, List<Booking> existingBookings, List<DateRange> ranges);
        int CalculateTotalBookedQuantityForBookings(IEnumerable<Booking> bookings);
    }
}
