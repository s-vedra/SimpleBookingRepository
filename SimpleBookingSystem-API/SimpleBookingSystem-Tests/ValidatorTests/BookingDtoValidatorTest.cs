using SimpleBookingSystem_DTO;
using SimpleBookingSystem_Exceptions;

namespace SimpleBookingSystem_Tests.ValidatorTests
{
    public class BookingDtoValidatorTest
    {
        [Fact(DisplayName = "Should validate booking")]
        public void ShouldValidateBooking_ValidateBooking()
        {
            //Arrange
            var bookingDto = new BookingDTO()
            {
                BookedQuantity = 10, 
                DateFrom = DateTime.Parse("2023-05-10"),
                DateTo = DateTime.Parse("2023-05-15"),
                ResourceId = 1
            };

            //Act
            var result = bookingDto.ValidateBooking();
            var expected = true;

            //Assert
            Assert.Equal(result, expected);
        }

        [Fact(DisplayName = "Should throw error if booked quantity is below 0 or time range is wrong")]
        public void ShouldThrowErrorIfBookedQuantityIsBelowZeroOrTimeRangeIsWrong_ValidateBooking()
        {
            //Arrange
            var bookingDto = new BookingDTO()
            {
                BookedQuantity = 0,
                DateFrom = DateTime.Parse("2023-05-15"),
                DateTo = DateTime.Parse("2023-05-10"),
                ResourceId = 1
            };

            //Act and Assert
            Assert.Throws<CoreException>(() => bookingDto.ValidateBooking());
        }
    }
}
