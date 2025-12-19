using AppAgency.Domain.Model;
using AppAgency.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AppAgency.DAL.Repositories
{
    public class SqlDestinationRepo : IDestinationRepo
    {
        private readonly AgenceDbContext _dbContext;

        public SqlDestinationRepo(AgenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Destination Get(int id) 
        {
            return _dbContext.Destinations
                .Include(d => d.Activities)
                .FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Destination> GetAll()
        {
            try
            {
                return _dbContext.Destinations;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "au repo");
                throw ex;
            }
        }

        public Destination Insert(Destination destination)
        {
            try
            {
                _dbContext.Destinations.Add(destination);
                _dbContext.SaveChanges();
                Console.WriteLine("Destination ajoutée avec succès!");
                return destination;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "au repo");
                throw ex;
            }
        }
    }
}
