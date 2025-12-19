namespace AppAgency.Domain.Model
{
    public class Destination
    {
        public int Id { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string Description { get; set; }

        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
        //public IEnumerable<Booking> Bookings { get => Activities.SelectMany(a => a.Bookings); }
    }
}
