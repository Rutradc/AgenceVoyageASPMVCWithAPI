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
        public IEnumerable<DisplayActivity> Activities { get; set; } = new List<DisplayActivity>();

        public DisplayDestination(int id, string country, string city, string description, IEnumerable<DisplayActivity> activities)
        {
            Id = id;
            Country = country;
            City = city;
            Description = description;
            Activities = activities;
        }
    }
}
