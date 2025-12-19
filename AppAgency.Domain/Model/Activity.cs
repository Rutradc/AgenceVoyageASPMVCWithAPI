using System.Text.Json.Serialization;

namespace AppAgency.Domain.Model
{
    public class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public int DestinationId { get; set; }
        [JsonIgnore]
        public Destination Destination { get; set; }
        [JsonIgnore]
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
