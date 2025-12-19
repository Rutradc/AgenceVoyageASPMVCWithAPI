using AppAgency.BLL.Services.Interfaces;
using AppAgency.Domain.Model;
using AppAgency.Domain.Repositories;

namespace AppAgency.BLL.Services.Implementations
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepo _repo;

        public ActivityService(IActivityRepo repo)
        {
            _repo = repo;
        }

        public Activity Create(Activity activity)
        {
            return _repo.Insert(activity);
        }
    }
}
