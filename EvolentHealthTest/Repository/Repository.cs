using EvolentHealthTest.DbContexts;
using System.Threading.Tasks;

namespace EvolentHealthTest.Repository
{
    /// <summary>
    /// Repository
    /// </summary>
    public class Repository
    {
        #region Private Member

        private readonly EvolentHealthDatabaseContext _dbContext;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Initialize database context
        /// </summary>
        /// <param name="dbContext">evolent health db context</param>
        public Repository(EvolentHealthDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Pubic Method

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public Task SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
