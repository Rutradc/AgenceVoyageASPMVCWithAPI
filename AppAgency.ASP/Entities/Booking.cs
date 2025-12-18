namespace AppAgency.ASP.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public required string ClientName { get; set; }

        public Destination Destination { get; set; }
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}
