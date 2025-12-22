using AppAgency.ASP.Entities;
using AppAgency.ASP.Models;

namespace AppAgency.ASP.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAll();
        Task<Booking> Insert(CreateBookingForm booking);
        Task Delete(int id);
    }
}
