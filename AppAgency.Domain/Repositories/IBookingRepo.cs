using AppAgency.Domain.Model;

namespace AppAgency.Domain.Repositories
{
    public interface IBookingRepo
    {
        IEnumerable<Booking> GetAll();
        Booking Insert(Booking booking, IEnumerable<int> activitiesIds);
    }
}
