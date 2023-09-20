using Nop.Core;
using Nop.Plugin.RasteBazar.Controllers;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nop.Plugin.RasteBazar
{
    public class RasteBazarPlugin : BasePlugin
    {
        #region Fields

        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public RasteBazarPlugin(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }

        #endregion

        #region Methods

        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/RasteBazar/Configure";
        }

        public override async Task InstallAsync()
        {
            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
            await base.UninstallAsync();
        }

        #endregion

    }
}