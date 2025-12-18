using AppAgency.Domain.Model;

namespace AppAgency.Domain.Repositories
{
    public interface IDestinationRepo
    {
        Destination Get(int id);
        IEnumerable<Destination> GetAll();
        Destination Insert(Destination destination);
    }
}
