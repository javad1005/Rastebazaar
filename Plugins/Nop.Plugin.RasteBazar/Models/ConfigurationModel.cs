namespace Nop.Plugin.RasteBazar.Models
{
    /// <summary>
    /// Represents a configuration model
    /// </summary>
    public class ConfigurationModel
    {
        #region Ctor

        public ConfigurationModel()
        {
        }

        #endregion

        #region Properties

        public string PageName { get; set; }

        public string PageTitle { get; set; }

        public string PageDescription { get; set; }

        public bool HideList { get; set; }

        public bool UpdateDataBase { get; set; } = false;

        #endregion
    }
}