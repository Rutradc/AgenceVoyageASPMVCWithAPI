namespace AppAgency.ASP.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public required string ClientName { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
