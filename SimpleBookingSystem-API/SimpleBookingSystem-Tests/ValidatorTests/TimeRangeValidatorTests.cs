using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_Services.Implementation;

namespace SimpleBookingSystem_Tests.TimeRangeValidatorTests
{
    public class TimeRangeValidatorTests
    {
        [Fact(DisplayName = "Should get overlapping date ranges")]
        public void ShouldGetOverlappingRanges_GetOverlappingDateRanges()
        {
            //Arrange
            var rangeToCheck = new DateRange { Id = 4, DateFrom = new DateTime(2023, 04, 24), DateTo = new DateTime(2023, 04, 30) };
            var ranges = new List<DateRange>
        {
            new DateRange {Id = 1, DateFrom = new DateTime(2023, 04, 27), DateTo = new DateTime(2023, 04, 27) },
            new DateRange {Id = 2,  DateFrom = new DateTime(2023, 04, 25), DateTo = new DateTime(2023, 05, 01) },
            new DateRange {Id = 3, DateFrom = new DateTime(2023, 05, 15), DateTo = new DateTime(2023, 05, 20) }
        };

            // Act
            var overlappingRanges = TimeRangeValidator.GetOverlappingDateRanges(rangeToCheck, ranges);

            // Assert
            Assert.Collection(overlappingRanges,
                item => Assert.Equal(1, item.Id),
                item => Assert.Equal(2, item.Id)
            );
        }

        [Theory(DisplayName = "Should check if timestamps are in range")]
        [InlineData("2023-05-01", "2023-05-05", "2023-05-03", "2023-05-08", true)]
        [InlineData("2023-05-03", "2023-05-08", "2023-05-01", "2023-05-05", true)]
        [InlineData("2023-05-01", "2023-05-05", "2023-05-06", "2023-05-08", false)]
        [InlineData("2023-05-06", "2023-05-08", "2023-05-01", "2023-05-05", false)]
        public void ShouldCheckIfTimestampsAreInRange_IsTimestampWithinRange(string dateFrom1, string dateTo1, string dateFrom2, string dateTo2, bool expectedResult)
        {
            //Arrange
            var range = new DateRange() { Id = 1, DateFrom = DateTime.Parse(dateFrom1), DateTo = DateTime.Parse(dateTo1) };
            var rangeToCompare = new DateRange() { Id = 2, DateFrom = DateTime.Parse(dateFrom2), DateTo = DateTime.Parse(dateTo2) };

            //Act
            var result = TimeRangeValidator.IsTimestampWithinRange(range, rangeToCompare);

            //Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
