using EvolentHealthTest.Models;

namespace EvolentHealthTest.Extensions.Api
{
    /// <summary>
    /// String extensions 
    /// </summary>
    public static class StringExtensions
    {
        #region Public Static Method

        /// <summary>
        /// Get Database connection string based on production
        /// </summary>
        /// <param name="db">Database configuration</param>
        /// <param name="isProduction">Production</param>
        /// <returns>Returns the result</returns>
        public static string DatabaseConnectionString(this DatabaseConfiguration db, bool isProduction)
        {
            if (isProduction)
                return $"Server={db.ServerName};Database={db.DatabaseName};User ID={db.UserId};Password={db.Password};Encrypt=true;";
            return $"server={db.ServerName};database={db.DatabaseName};trusted_connection=true;Encrypt=false;";
        }

        #endregion
    }
}
