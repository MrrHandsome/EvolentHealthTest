using EvolentHealthTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvolentHealthTest.Extensions
{
    /// <summary>
    /// Evolent health model builder extensions
    /// </summary>
    public static class EvolentHealthModelBuilderExtensions
    {
        #region Public Static Method

        /// <summary>
        /// Configure evolent health context
        /// </summary>
        /// <param name="modelBuilder">Modelbuilder</param>
        public static void ConfigureEvolentHealthContext(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(item =>
            {
                item.ToTable("Contact");
                item.HasKey(i => i.Id);
                item.HasIndex(i => i.Email).IsUnique();
                item.Property(i => i.FirstName).IsRequired();
                item.Property(i => i.LastName).IsRequired();
                item.Property(i => i.PhoneNumber).IsRequired();
                item.Property(i => i.Status).IsRequired();
            });
        }

        #endregion
    }
}
