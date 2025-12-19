
using AppAgency.Domain.Model;
using AppAgency.Domain.Repositories;

namespace AppAgency.DAL.Repositories
{
    public class SqlActivityRepo : IActivityRepo
    {
        private readonly AgenceDbContext _dbContext;

        public SqlActivityRepo(AgenceDbContext context)
        {
            _dbContext = context;
        }

        public Activity Insert(Activity activity)
        {
            try
            {
                _dbContext.Activities.Add(activity);
                _dbContext.SaveChanges();
                return activity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "au repo");
                throw ex;
            }
        }
    }
}
