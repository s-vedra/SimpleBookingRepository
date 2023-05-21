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
        private readonly IEmailService _emailService;
        public BookingService(IBookingRepository bookingRepository, IResourceRepository resourceRepository, IDateRangeRepository dateRangeRepository, IBookingQueryService bookingQueryService, IEmailService emailService)
        {
            _bookingRepository = bookingRepository;
            _resourceRepository = resourceRepository;
            _dateRangeRepository = dateRangeRepository;
            _bookingQueryService = bookingQueryService;
            _emailService = emailService;
        }

        public void SaveBookingAndSendEmailToAdmin(BookingDTO bookingDto)
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

            var overlappingBookings = _bookingQueryService.GetOverlappingBookings(rangeToCheck,bookings, ranges);
            CheckResourceAvailability(resource, booking, overlappingBookings);
            var bookingId = _bookingRepository.AddEntity(booking);
            _emailService.SendEmailForReceivedBooking(bookingId);
        }

        private void CheckResourceAvailability(Resource resource, Booking booking, List<Booking> overlappingBookings)
        {
            if (!IsResourceAvailable(resource, booking, overlappingBookings))
            {
                throw new CoreException("There are no bookings available");
            }
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
