using EvolentHealthTest.Entities;
using EvolentHealthTest.Extensions;
using EvolentHealthTest.Interface;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EvolentHealthTest.DbContexts
{
    /// <summary>
    /// Database context of evolenthealth
    /// </summary>
    public class EvolentHealthDatabaseContext : DbContext, IEvolentHealthDatabaseContext
    {
        #region Private Member

        private readonly ConfigurationStoreOptions _storeOptions;

        #endregion

        #region Public Property
        public DbSet<Contact> contacts { get; set; }

        #endregion

        #region Public Constructor

        /// <summary>
        ///  Initialize database connectionString
        /// </summary>
        public EvolentHealthDatabaseContext() : this("server=(local)\\SQLEXPRESS2012;database=evolenthealth;trusted_connection=yes;".StrToContextOptions<EvolentHealthDatabaseContext>(),
            new ConfigurationStoreOptions())
        {
        }

        /// <summary>
        /// Initialize datacontxtoptions and configurations
        /// </summary>
        /// <param name="options">Databasecontextoptions</param>
        /// <param name="storeOptions">Configurationstoreoptions</param>
        public EvolentHealthDatabaseContext(DbContextOptions<EvolentHealthDatabaseContext> options, ConfigurationStoreOptions storeOptions)
            : base(options)
        {
            _storeOptions = storeOptions;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Save the at the end of each operation
        /// </summary>
        /// <returns>Returns the result</returns>
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        #endregion

        #region Protected Override Method

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureEvolentHealthContext();
        }

        #endregion
    }
}
