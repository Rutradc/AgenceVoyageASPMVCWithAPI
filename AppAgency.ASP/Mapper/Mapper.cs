using AppAgency.ASP.Entities;
using AppAgency.ASP.Models;

namespace AppAgency.ASP.Mapper
{
    public static class Mapper
    {
        public static DisplayDestination ToDisplay(this Destination entity)
        {
            return new DisplayDestination(
                entity.Id,
                entity.Country,
                entity.City,
                entity.Description,
                entity.Activities.Select(a => a.ToDisplay())
                );
        }
        public static DisplayActivity ToDisplay(this Activity entity)
        {
            return new DisplayActivity(
                entity.Id,
                entity.Title,
                entity.Description,
                entity.Price
                );
        }
        public static DisplayBooking ToDisplay(this Booking entity)
        {
            return new DisplayBooking(
                entity.Id,
                entity.BookingDate,
                entity.ClientName,
                entity.Activities.Select(a => a.ToDisplay()),
                entity.Destination.ToDisplay()
                );
        }
    }
}
