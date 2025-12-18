using AppAgency.ASP.Entities;
using System.ComponentModel;

namespace AppAgency.ASP.Models
{
    public class DisplayDestination
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Pays")]
        public string Country { get; set; }
        [DisplayName("Ville")]
        public string City { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public DisplayDestination(int id, string country, string city, string description, ICollection<Activity> activities, ICollection<Booking> bookings)
        {
            Id = id;
            Country = country;
            City = city;
            Description = description;
            Activities = activities;
            Bookings = bookings;
        }
    }
}
