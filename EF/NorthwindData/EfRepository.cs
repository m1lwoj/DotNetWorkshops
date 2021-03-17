using NorthwindData.Models;

namespace NorthwindData
{
    public abstract class EfRepository
    {
        protected NorthwindContext _dbContext;

        protected EfRepository(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
