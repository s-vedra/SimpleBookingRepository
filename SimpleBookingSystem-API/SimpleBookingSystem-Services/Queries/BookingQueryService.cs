using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_Exceptions;
using SimpleBookingSystem_Services.Abstraction;
using SimpleBookingSystem_Services.ValidatorUtility;

namespace SimpleBookingSystem_Services.Queries
{
    public class BookingQueryService : IBookingQueryService
    {
        public int CalculateTotalBookedQuantityForBookings(IEnumerable<Booking> bookings)
        {
            if (!bookings.Any())
                throw new CoreException("There are no bookings");
            return bookings.Select(x => x.BookedQuantity).Sum();
        }

        public List<Booking> GetOverlappingBookings(DateRange dateRange, List<Booking> existingBookings, List<DateRange> ranges)
        {
            var overlappedRanges = TimeRangeValidator.GetOverlappingDateRanges(dateRange, ranges);
            if (!overlappedRanges.Any())
            {
                return new List<Booking>();
            }
            var overlappingIds = overlappedRanges.Select(r => r.Id).ToHashSet();
            return existingBookings.Where(b => overlappingIds.Contains(b.DateRangeId)).ToList();
        }
    }
}
