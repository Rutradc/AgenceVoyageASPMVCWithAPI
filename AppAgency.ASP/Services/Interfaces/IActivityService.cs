using AppAgency.ASP.Entities;
using AppAgency.ASP.Models;

namespace AppAgency.ASP.Services.Interfaces
{
    public interface IActivityService
    {
        Task<Activity> Insert(CreateActivityForm activity);
    }
}
