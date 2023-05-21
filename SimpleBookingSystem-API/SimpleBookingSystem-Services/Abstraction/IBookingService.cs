using SimpleBookingSystem_DTO;

namespace SimpleBookingSystem_Services.Abstraction
{
    public interface IBookingService
    {
        void SaveBookingAndSendEmailToAdmin(BookingDTO bookingDto);
    }
}
