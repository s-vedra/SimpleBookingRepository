using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_DTO;
using SimpleBookingSystem_Mappers;

namespace SimpleBookingSystem_Tests.MappingTests
{
    public class BookingMapperTest
    {
        [Fact(DisplayName = "Should map from Dto booking object to domain")]
        public void ShouldMapFromDtoBookingObjectToDomain_ToDomain()
        {
            var bookingDto = new BookingDTO()
            {
                ResourceId = 1,
                BookedQuantity = 5,
                DateFrom = DateTime.Today,
                DateTo = DateTime.Today,
                UserId = 1
            };

            var booking = bookingDto.ToDomain();

            Assert.IsType<Booking>(booking);
        }

        [Fact(DisplayName = "Should map from domain booking object to dto")]
        public void ShouldMapFromDomainBookingObjectToDto_ToDto()
        {
            var booking = new Booking()
            {
                ResourceId = 1,
                BookedQuantity = 5,
                DateRange = new DateRange()
                {
                    DateFrom = DateTime.Today,
                    DateTo = DateTime.Today,
                },
                UserId = 1
            };

            var bookingDto = booking.ToDto();

            Assert.IsType<BookingDTO>(bookingDto);
        }
    }
}
