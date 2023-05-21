using SimpleBookingSystem_Services.Abstraction;

namespace SimpleBookingSystem_Services.Implementation
{
    public class EmailService : IEmailService
    {
        public void SendEmailForReceivedBooking(int bookingId)
        {
            Console.WriteLine($"EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {bookingId}");
        }
    }
}
