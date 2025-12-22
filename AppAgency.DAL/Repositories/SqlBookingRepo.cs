using AppAgency.Domain.Model;
using AppAgency.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AppAgency.DAL.Repositories
{
    public class SqlBookingRepo : IBookingRepo
    {
        private readonly AgenceDbContext _dbContext;

        public SqlBookingRepo(AgenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Booking Insert(Booking booking, IEnumerable<int> activitiesIds)
        {
            try
            {
                IEnumerable<Activity> activities = _dbContext.Activities.Where(a => activitiesIds.Contains(a.Id)).ToList();
                if (!activities.All(a => a.DestinationId == activities.ElementAt(0).DestinationId))
                    throw new ApplicationException("All Activities linked to this Booking are not referencing the same DestinationId");
                booking.Activities = activities.ToList();
                _dbContext.Bookings.Add(booking);
                _dbContext.SaveChanges();
                return booking;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "au repo");
                throw ex;
            }
        }

        public IEnumerable<Booking> GetAll()
        {
            IEnumerable<Booking> bookings = _dbContext.Bookings
                .Include(b => b.Activities)
                .ToList();
            IEnumerable<int> destinationIds = bookings
                .SelectMany(b => b.Activities.Select(a => a.DestinationId))
                .Distinct()
                .ToList();
            IEnumerable<Destination> destinations = _dbContext.Destinations
                .Where(d => destinationIds.Contains(d.Id))
                .AsNoTracking()
                .ToList();
            foreach (Booking booking in bookings)
            {
                booking.Destination = destinations.FirstOrDefault(d => d.Id == booking.Activities.ElementAt(0).DestinationId);
            }
            return bookings;
        }

        public bool Delete(int id)
        {
            try
            {
                Booking booking = _dbContext.Bookings.FirstOrDefault(b => b.Id == id);
                if (booking == null)
                    return false;
                _dbContext.Bookings.Remove(booking);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
