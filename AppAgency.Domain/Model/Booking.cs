using System.ComponentModel.DataAnnotations.Schema;

namespace AppAgency.Domain.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public required string ClientName { get; set; }
        //[NotMapped]
        //public ICollection<int> ActivitiesIds { get; set; } = new List<int>();
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
        [NotMapped]
        public Destination Destination { get; set; }
    }
}
