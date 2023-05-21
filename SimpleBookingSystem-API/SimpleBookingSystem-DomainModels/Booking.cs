namespace SimpleBookingSystem_DomainModels
{
    public class Booking
    {
        public int Id { get; set; }
        public int DateRangeId { get; set; }
        public DateRange DateRange { get; set; }
        public int BookedQuantity { get; set; }
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public class DateRange
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
