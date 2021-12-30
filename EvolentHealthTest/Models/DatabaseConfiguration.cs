namespace EvolentHealthTest.Models
{
    /// <summary>
    /// Database configuration of application
    /// </summary>
    public class DatabaseConfiguration
    {
        #region Public Property

        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }

        #endregion
    }
}
