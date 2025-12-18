using AppAgency.Domain.Model;

namespace AppAgency.BLL.Services.Interfaces
{
    public interface IDestinationService
    {
        Destination Get(int id);
        IEnumerable<Destination> GetAll();
        Destination Create(Destination destination);
    }
}
