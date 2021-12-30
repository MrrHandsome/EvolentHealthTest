using Microsoft.EntityFrameworkCore;

namespace EvolentHealthTest.Extensions
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtensions
    {
        #region Public Method

        /// <summary>
        /// String to context options
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connectionString">Connection string</param>
        /// <returns>Returns the result</returns>
        public static DbContextOptions<T> StrToContextOptions<T>(this string connectionString) where T : DbContext
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer<T>(new DbContextOptionsBuilder<T>(), connectionString).Options;
        }

        #endregion
    }
}
