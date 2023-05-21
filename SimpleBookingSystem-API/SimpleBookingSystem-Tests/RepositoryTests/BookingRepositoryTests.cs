using Moq;
using SimpleBookingSystem_DAL.Abstraction;
using SimpleBookingSystem_DomainModels;

namespace SimpleBookingSystem_Tests.RepositoryTests
{
    public class BookingRepositoryTests
    {
        private List<Booking> Bookings { get; set; }
        private readonly Mock<IBookingRepository> _bookingRepository;
        public BookingRepositoryTests()
        {
            Bookings = GetBookings();
            _bookingRepository = new Mock<IBookingRepository>();
        }

        [Fact(DisplayName = "Should add a new booking in the list")]
        public void ShouldAddANewBookingInTheList_AddEntity()
        {
            var booking = new Booking()
            {
                ResourceId = 1,
                DateRangeId = 1,
                DateRange = new DateRange()
                {
                    DateFrom = new DateTime(2023, 04, 24),
                    DateTo = new DateTime(2023, 04, 30)
                },
                BookedQuantity = 5
            };

            _bookingRepository.Setup(x => x.AddEntity(It.IsAny<Booking>())).Returns(4);
            var result = _bookingRepository.Object.AddEntity(booking);

            Assert.Equal(4, result);
        }

        [Fact(DisplayName = "Should get all bookings")]
        public void ShouldGetAllBookings_GetEntities()
        {
            _bookingRepository.Setup(x => x.GetEntities()).Returns(Bookings.AsQueryable());
            var result = _bookingRepository.Object.GetEntities();

            Assert.Equal(Bookings, result);
        }

        [Fact(DisplayName = "Should get booking")]
        public void ShouldGetBooking_GetEntity()
        {
            var booking = new Booking()
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
            };

            _bookingRepository.Setup(x => x.GetEntity(It.IsAny<int>())).Returns(booking);
            var result = _bookingRepository.Object.GetEntity(booking.Id);

            Assert.Equal(booking, result);
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
    }
}
