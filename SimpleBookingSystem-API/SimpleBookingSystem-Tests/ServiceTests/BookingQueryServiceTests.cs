using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_Exceptions;
using SimpleBookingSystem_Services.Abstraction;
using SimpleBookingSystem_Services.Queries;

namespace SimpleBookingSystem_Tests.ServiceTests
{
    public class BookingQueryServiceTests
    {
        private List<Booking> Bookings { get; set; }
        private List<DateRange> DateRanges { get; set; }
        private readonly IBookingQueryService _bookingQueryService;
        public BookingQueryServiceTests()
        {
            Bookings = GetBookings();
            DateRanges = GetDateRanges();
            _bookingQueryService = new BookingQueryService();
        }

        [Fact(DisplayName = "Should get overlapping bookings")]
        public void ShouldGetOverlappingBookings_GetOverlappingBookings()
        {
            //Arrange
            var dateRange = new DateRange()
            {
                DateFrom = new DateTime(2023, 04, 24),
                DateTo = new DateTime(2023, 04, 30)
            };

            //Act
            var result = _bookingQueryService.GetOverlappingBookings(dateRange, Bookings, DateRanges);
            var overlappingBookings = new List<Booking>()
            {
                Bookings[0],
                Bookings[1],
                Bookings[2]
            };

            //Assert
            Assert.Equal(overlappingBookings, result);
        }

        [Fact(DisplayName = "Should get calculated booked quantity")]
        public void ShouldGetCalculatedBookedQuantity_CalculateTotalBookedQuantityForBookings()
        {
            //Arrange
            var expected = 18;

            //Act
            var result = _bookingQueryService.CalculateTotalBookedQuantityForBookings(Bookings);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Should throw exception if there are no bookings")]
        public void ShouldThrowExceptionIfThereAreNoBookings_CalculateTotalBookedQuantityForBookings()
        {
            //Arrange
            var bookings = new List<Booking>();

            //Act and Assert
            Assert.Throws<CoreException>(() => _bookingQueryService.CalculateTotalBookedQuantityForBookings(bookings));
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
