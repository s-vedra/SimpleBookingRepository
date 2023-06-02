using Moq;
using SimpleBookingSystem_DAL.Abstraction;
using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_DTO;
using SimpleBookingSystem_Exceptions;
using SimpleBookingSystem_Services.Abstraction;
using SimpleBookingSystem_Services.Implementation;

namespace SimpleBookingSystem_Tests.ServiceTests
{
    public class BookingServiceTests
    {
        private readonly Mock<IBookingRepository> _bookingRepository;
        private readonly Mock<IResourceRepository> _resourceRepository;
        private readonly Mock<IDateRangeRepository> _dateRangeRepository;
        private readonly Mock<IBookingQueryService> _bookingQueryService;
        private readonly IBookingService _bookingService;
        private List<Booking> Bookings { get; set; }
        private List<DateRange> DateRanges { get; set; }
        public BookingServiceTests()
        {
            _bookingRepository = new Mock<IBookingRepository>();
            _resourceRepository = new Mock<IResourceRepository>();
            _dateRangeRepository = new Mock<IDateRangeRepository>();
            _bookingQueryService = new Mock<IBookingQueryService>();
            _bookingService = new BookingService(_bookingRepository.Object,
                _resourceRepository.Object,
                _dateRangeRepository.Object,
                _bookingQueryService.Object);
            Bookings = GetBookings();
            DateRanges = GetDateRanges();
        }

        [Fact(DisplayName = "Should save booking and send email to admin")]
        public void ShouldSaveBookingAndSendEmailToAdmin_SaveBooking()
        {
            //Arrange
            var bookingDto = new BookingDTO
            {
                ResourceId = 2,
                BookedQuantity = 5,
                DateFrom = new DateTime(2023, 04, 26),
                DateTo = new DateTime(2023, 04, 26)
            };

            var mockResource = new Resource
            {
                Id = 2,
                Title = "Resource2",
                Quantity = 10
            };

            var overlappedBookings = new List<Booking>() { Bookings[1] };

            _resourceRepository.Setup(x => x.GetEntity(It.IsAny<int>())).Returns(mockResource);
            _bookingRepository.Setup(x => x.GetEntities()).Returns(Bookings.AsQueryable());
            _dateRangeRepository.Setup(x => x.GetEntities()).Returns(DateRanges.AsQueryable());
            _bookingQueryService
             .Setup(x => x.GetOverlappingBookings(
             It.IsAny<DateRange>(),
             It.IsAny<List<Booking>>(),
             It.IsAny<List<DateRange>>()))
            .Returns(overlappedBookings);
            _bookingQueryService.Setup(x => x.CalculateTotalBookedQuantityForBookings(
               It.IsAny<List<Booking>>()))
               .Returns(3);

            // Act
            _bookingService.SaveBooking(bookingDto);

            // Assert
            _bookingRepository.Verify(x => x.AddEntity(It.IsAny<Booking>()), Times.Once);
        }

        [Fact(DisplayName = "Should throw exception if no quantity is available")]
        public void ShouldThrowExceptionIfNoQuantityIsAvailable_SaveBookingAndSendEmailToAdmin()
        {
            //Arrange
            var bookingDto = new BookingDTO
            {
                ResourceId = 1,
                BookedQuantity = 5,
                DateFrom = new DateTime(2023, 04, 27),
                DateTo = new DateTime(2023, 04, 27)
            };

            var mockResource = new Resource
            {
                Id = 1,
                Title = "Resource1",
                Quantity = 10
            };

            var overlappedBookings = new List<Booking>()
            {
                Bookings.First(),
                Bookings.Last()
            };

            _resourceRepository.Setup(x => x.GetEntity(It.IsAny<int>())).Returns(mockResource);
            _bookingRepository.Setup(x => x.GetEntities()).Returns(Bookings.AsQueryable());
            _dateRangeRepository.Setup(x => x.GetEntities()).Returns(DateRanges.AsQueryable());
            _bookingQueryService
             .Setup(x => x.GetOverlappingBookings(
             It.IsAny<DateRange>(),
             It.IsAny<List<Booking>>(),
             It.IsAny<List<DateRange>>()))
            .Returns(overlappedBookings);
            _bookingQueryService.Setup(x => x.CalculateTotalBookedQuantityForBookings(
                It.IsAny<List<Booking>>()))
                .Returns(10);

            //Act and Assert
            Assert.Throws<CoreException>(() => _bookingService.SaveBooking(bookingDto));
        }

        private List<Booking> GetBookings()
        {
            return new List<Booking>()
            {
                new Booking()
                {
                    Id = 1,
                    ResourceId = 1,
                    DateRangeId = 1,
                    DateRange = new DateRange()
                    {
                        Id = 1,
                        DateFrom = new DateTime(2023, 04, 24),
                        DateTo = new DateTime(2023, 04, 30)
                    },
                    BookedQuantity = 5
                },
                new Booking()
                {
                    Id = 2,
                    ResourceId = 2,
                    DateRangeId = 2,
                    DateRange = new DateRange()
                    {
                        Id = 2,
                        DateFrom = new DateTime(2023, 04, 25),
                        DateTo = new DateTime(2023, 04, 29)
                    },
                    BookedQuantity = 3
                },
                new Booking()
                {
                    Id = 3,
                    ResourceId = 1,
                    DateRangeId = 3,
                    DateRange = new DateRange()
                    {
                        Id = 3,
                        DateFrom = new DateTime(2023, 04, 25),
                        DateTo = new DateTime(2023, 04, 29)
                    },
                    BookedQuantity = 5
                },
                new Booking()
                {
                    Id = 4,
                    ResourceId = 1,
                    DateRangeId = 4,
                    DateRange = new DateRange()
                    {
                        Id = 4,
                        DateFrom = new DateTime(2023, 06, 17),
                        DateTo = new DateTime(2023, 06, 19)
                    },
                    BookedQuantity = 5
                }
            };
        }

        private List<DateRange> GetDateRanges()
        {
            return new List<DateRange>()
            {
                new DateRange
                {
                    Id = 1,
                    DateFrom = new DateTime(2023, 04, 24),
                    DateTo = new DateTime(2023, 04, 30)
                },
                new DateRange
                {
                    Id = 2,
                    DateFrom = new DateTime(2023, 04, 25),
                    DateTo = new DateTime(2023, 04, 29)
                },
                new DateRange
                {
                    Id = 3,
                    DateFrom = new DateTime(2023, 04, 25),
                    DateTo = new DateTime(2023, 04, 29)
                },
                new DateRange()
               {
                    Id = 4,
                    DateFrom = new DateTime(2023, 06, 17),
                    DateTo = new DateTime(2023, 06, 19)
               },
            };
        }
    }
}
