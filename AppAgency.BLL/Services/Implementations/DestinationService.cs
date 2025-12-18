using AppAgency.BLL.Services.Interfaces;
using AppAgency.Domain.Model;
using AppAgency.Domain.Repositories;

namespace AppAgency.BLL.Services.Implementations
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepo _repo;

        public DestinationService(IDestinationRepo repo)
        {
            _repo = repo;
        }
        public Destination Get(int id)
        {
            return _repo.Get(id);
        }

        public IEnumerable<Destination> GetAll()
        {
            return _repo.GetAll();
        }

        public Destination Create(Destination destination)
        {
            return _repo.Insert(destination);
        }

    }
}
