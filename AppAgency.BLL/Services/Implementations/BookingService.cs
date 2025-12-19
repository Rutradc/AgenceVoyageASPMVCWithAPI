using AppAgency.BLL.Services.Interfaces;
using AppAgency.Domain.Model;
using AppAgency.Domain.Repositories;

namespace AppAgency.BLL.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _repo;

        public BookingService(IBookingRepo repo)
        {
            _repo = repo;
        }

        public Booking Create(Booking booking, IEnumerable<int> activitiesIds)
        {
            return _repo.Insert(booking, activitiesIds);
        }

        public IEnumerable<Booking> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
