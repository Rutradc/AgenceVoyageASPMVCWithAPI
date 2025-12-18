using AppAgency.Domain.Model;

namespace AppAgency.Domain.Repositories
{
    public interface IActivityRepo
    {
        Activity Insert(Activity activity);
    }
}
