using AppAgency.Domain.Model;

namespace AppAgency.BLL.Services.Interfaces
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAll();
        Booking Create(Booking booking, IEnumerable<int> activitiesIds);
        bool Delete(int id);
    }
}
