using SimpleBookingSystem_Exceptions;

namespace SimpleBookingSystem_DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BookedQuantity { get; set; }
        public int ResourceId { get; set; }
        public int UserId { get; set; }

        public bool ValidateBooking()
        {
            if (BookedQuantity <= 0)
            {
                throw new CoreException("Please check the booking quantity and try again");
            }
            if (DateTo < DateFrom)
            {
                throw new CoreException("Please check the dates and try again");
            }
            return true;
        }
    }
}
