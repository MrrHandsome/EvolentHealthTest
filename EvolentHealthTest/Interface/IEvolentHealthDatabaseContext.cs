using EvolentHealthTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EvolentHealthTest.Interface
{
    /// <summary>
    /// Evolent health database context
    /// </summary>
    public interface IEvolentHealthDatabaseContext : IDisposable
    {
        #region Public Property

        public DbSet<Contact> contacts { get; set; }

        #endregion

        #region Methods

        int SaveChanges();
        Task<int> SaveChangesAsync();

        #endregion
    }
}
