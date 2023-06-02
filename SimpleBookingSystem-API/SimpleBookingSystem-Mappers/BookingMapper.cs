using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_DTO;

namespace SimpleBookingSystem_Mappers
{
    public static class BookingMapper
    {
        public static BookingDTO ToDto(this Booking resource)
        {
            return new BookingDTO()
            {
                Id = resource.Id,
                DateFrom = resource.DateRange.DateFrom,
                DateTo = resource.DateRange.DateTo,
                BookedQuantity = resource.BookedQuantity,
                ResourceId = resource.ResourceId,
                UserId = resource.UserId,
                DateRangeId = resource.DateRangeId,
                ResourceName = resource.Resource.Title
            };
        }

        public static Booking ToDomain(this BookingDTO resource)
        {
            return new Booking()
            {
                Id = resource.Id,
                DateRange = new DateRange()
                {
                    Id = resource.DateRangeId,
                    DateFrom = resource.DateFrom,
                    DateTo = resource.DateTo,
                },
                BookedQuantity = resource.BookedQuantity,
                ResourceId = resource.ResourceId,
                UserId = resource.UserId,
                DateRangeId = resource.DateRangeId
            };
        }
    }
}
