namespace AppAgency.ASP.Models
{
    public class DisplayBooking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public string ClientName { get; set; }

        public IEnumerable<DisplayActivity> Activities { get; set; } = new List<DisplayActivity>();
        public DisplayDestination Destination { get; set; }

        public DisplayBooking(int id, DateTime bookingDate, string clientName, IEnumerable<DisplayActivity> activities, DisplayDestination destination)
        {
            Id = id;
            BookingDate = bookingDate;
            ClientName = clientName;
            Activities = activities;
            Destination = destination;
        }
    }
}
