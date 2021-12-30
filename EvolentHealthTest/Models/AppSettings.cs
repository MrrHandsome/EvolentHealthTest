namespace EvolentHealthTest.Models
{
    /// <summary>
    /// App setting of application
    /// </summary>
    public class AppSettings
    {
        #region Public property

        public DatabaseConfiguration DatabaseConfiguration { get; set; }
        public string[] AllowOrigin { get; set; }
        public string BaseRoute { get; set; }
        public bool SwaggerEnabled { get; set; }
        public string ApplicationUrl { get; set; }
        public string AllowedHosts { get; set; }

        #endregion
    }
}
