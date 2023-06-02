using SimpleBookingSystem_DAL.Abstraction;
using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_DTO;
using SimpleBookingSystem_Exceptions;
using SimpleBookingSystem_Mappers;
using SimpleBookingSystem_Services.Abstraction;

namespace SimpleBookingSystem_Services.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IResourceRepository _resourceRepository;
        private readonly IDateRangeRepository _dateRangeRepository;
        private readonly IBookingQueryService _bookingQueryService;
        public BookingService(IBookingRepository bookingRepository,
            IResourceRepository resourceRepository,
            IDateRangeRepository dateRangeRepository,
            IBookingQueryService bookingQueryService)
        {
            _bookingRepository = bookingRepository;
            _resourceRepository = resourceRepository;
            _dateRangeRepository = dateRangeRepository;
            _bookingQueryService = bookingQueryService;
        }

        public void CancelBookingAndRemoveDateRange(int id)
        {
            var booking = _bookingRepository.GetEntity(id);
            var dateRange = _dateRangeRepository.GetEntity(booking.DateRangeId);
            _bookingRepository.RemoveEntity(booking);
            _dateRangeRepository.RemoveEntity(dateRange);
        }

        public IEnumerable<BookingDTO> GetAllBookings(int id)
        {
            var bookings = _bookingRepository.GetEntities().Where(x => x.UserId == id);
            if (!bookings.Any())
                throw new CoreException("No bookings");
            return bookings.Select(x => 
            new Booking()
            {   
                Id = x.Id,
                BookedQuantity = x.BookedQuantity,
                DateRange = _dateRangeRepository.GetEntity(x.DateRangeId),
                Resource = _resourceRepository.GetEntity(x.ResourceId),
                DateRangeId = x.DateRangeId,
                ResourceId = x.ResourceId
            }).Select(x => x.ToDto());
        }

        public IEnumerable<BookingDTO> GetAllBookings()
        {
            var bookings = _bookingRepository.GetEntities();
            if (!bookings.Any())
                throw new CoreException("No bookings");
            return bookings.Select(x =>
            new Booking()
            {
                Id = x.Id,
                BookedQuantity = x.BookedQuantity,
                DateRange = _dateRangeRepository.GetEntity(x.DateRangeId),
                Resource = _resourceRepository.GetEntity(x.ResourceId),
                DateRangeId = x.DateRangeId,
                ResourceId = x.ResourceId
            }).Select(x => x.ToDto());
        }

        public void SaveBooking(BookingDTO bookingDto)
        {
            var booking = bookingDto.ToDomain();
            var rangeToCheck = new DateRange()
            {
                DateFrom = booking.DateRange.DateFrom,
                DateTo = booking.DateRange.DateTo
            };
            var resource = _resourceRepository.GetEntity(booking.ResourceId);
            var bookings = _bookingRepository.GetEntities().Where(x => x.ResourceId == booking.ResourceId).ToList();
            var ranges = _dateRangeRepository.GetEntities().ToList();

            var overlappingBookings = _bookingQueryService.GetOverlappingBookings(rangeToCheck, bookings, ranges);
            CheckResourceAvailability(resource, booking, overlappingBookings);
            _bookingRepository.AddEntity(booking);
        }

        public void UpdateBookingOrDateRange(BookingDTO bookingDto)
        {
            var booking = bookingDto.ToDomain();
            _dateRangeRepository.UpdateEntity(booking.DateRange);
            _bookingRepository.UpdateEntity(booking);
        }

        private void CheckResourceAvailability(Resource resource, Booking booking, List<Booking> overlappingBookings)
        {
            if (!IsResourceAvailable(resource, booking, overlappingBookings))
                throw new CoreException("There are no bookings available");
        }

        private bool IsResourceAvailable(Resource resource, Booking booking, List<Booking> existingBookings)
        {
            int totalBookedQuantity = 0;
            if (existingBookings.Any())
                totalBookedQuantity = _bookingQueryService.CalculateTotalBookedQuantityForBookings(existingBookings);
            return ValidateResourceAvailabilityForBooking(resource.Quantity, booking.BookedQuantity, totalBookedQuantity);
        }

        private bool ValidateResourceAvailabilityForBooking(int availableResourceQuantity, int newBookingQuantity, int totalBookedQuantity)
        {
            if (newBookingQuantity > availableResourceQuantity)
                return false;
            else if (totalBookedQuantity >= availableResourceQuantity || (availableResourceQuantity - totalBookedQuantity) < newBookingQuantity)
                return false;
            return true;
        }
    }
}
