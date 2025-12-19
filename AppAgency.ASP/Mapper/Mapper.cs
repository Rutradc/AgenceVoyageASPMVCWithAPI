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
                entity.Activities.Select(a => a.ToDisplayActivity())
                );
        }
        public static DisplayActivity ToDisplayActivity(this Activity entity)
        {
            return new DisplayActivity(
                entity.Id,
                entity.Title,
                entity.Description,
                entity.Price
                );
        }
    }
}
