using Moq;
using SimpleBookingSystem_DAL.Abstraction;
using SimpleBookingSystem_DomainModels;

namespace SimpleBookingSystem_Tests.RepositoryTests
{
    public class DateRangeRepositoryTests
    {
        private List<DateRange> DateRanges { get; set; }
        private readonly Mock<IDateRangeRepository> _dateRangeRepository;
        public DateRangeRepositoryTests()
        {
            DateRanges = GetDateRanges();
            _dateRangeRepository = new Mock<IDateRangeRepository>();
        }

        [Fact(DisplayName = "Should add a new date range in the list")]
        public void ShouldAddANewDateRangeInTheList_AddEntity()
        {
            var dateRange = new DateRange
            {
                DateFrom = new DateTime(2023, 04, 24),
                DateTo = new DateTime(2023, 04, 30)
            };

            _dateRangeRepository.Setup(x => x.AddEntity(It.IsAny<DateRange>())).Returns(4);
            var result = _dateRangeRepository.Object.AddEntity(dateRange);

            Assert.Equal(4, result);
        }

        [Fact(DisplayName = "Should get all date ranges")]
        public void ShouldGetAllDateRanges_GetEntities()
        {
            _dateRangeRepository.Setup(x => x.GetEntities()).Returns(DateRanges.AsQueryable());
            var result = _dateRangeRepository.Object.GetEntities();

            Assert.Equal(DateRanges, result);
        }

        [Fact(DisplayName = "Should get date range")]
        public void ShouldGetDateRange_GetEntity()
        {
            var dateRange = new DateRange
            {
                Id = 1,
                DateFrom = new DateTime(2023, 04, 24),
                DateTo = new DateTime(2023, 04, 30)
            };

            _dateRangeRepository.Setup(x => x.GetEntity(It.IsAny<int>())).Returns(dateRange);
            var result = _dateRangeRepository.Object.GetEntity(dateRange.Id);

            Assert.Equal(dateRange, result);
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
