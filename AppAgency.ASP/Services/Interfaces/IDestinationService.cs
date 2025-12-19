using AppAgency.ASP.Entities;
using AppAgency.ASP.Models;

namespace AppAgency.ASP.Services.Interfaces
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAll();
        Task<Destination> GetById(int id);
        Task<Destination> Insert(CreateDestinationForm destination);
    }
}
