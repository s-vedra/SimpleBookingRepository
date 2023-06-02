using SimpleBookingSystem_DTO;

namespace SimpleBookingSystem_Services.Abstraction
{
    public interface IBookingService
    {
        void SaveBooking(BookingDTO bookingDto);
        void CancelBookingAndRemoveDateRange(int id);
        IEnumerable<BookingDTO> GetAllBookings();
        IEnumerable<BookingDTO> GetAllBookings(int id);
        void UpdateBookingOrDateRange(BookingDTO bookingDto);
    }
}
