namespace SimpleBookingSystem_Services.Abstraction
{
    public interface IEmailService
    {
        void SendEmailForReceivedBooking(int bookingId);
    }
}
