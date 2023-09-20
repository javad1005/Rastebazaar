using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Plugin.Widgets.StoreDetails.Components;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.StoreDetails
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class StoreDetailsPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        public StoreDetailsPlugin(ILocalizationService localizationService,
            ISettingService settingService,
            IWebHelper webHelper)
        {
            _localizationService = localizationService;
            _settingService = settingService;
            _webHelper = webHelper;
        }
        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the widget zones
        /// </returns>
        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageBottom });
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsStoreDetails/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public Type GetWidgetViewComponent(string widgetZone)
        {
            return typeof(WidgetsStoreDetailsViewComponent);
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            

            //settings
            var settings = new StoreDetailsSettings
            {
            };
            await _settingService.SaveSettingAsync(settings);

            //await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            //{
            //    ["Plugins.Widgets.NivoSlider.Picture1"] = "Picture 1",
            //    ["Plugins.Widgets.NivoSlider.Picture2"] = "Picture 2",
            //    ["Plugins.Widgets.NivoSlider.AltText.Hint"] = "Enter alternate text that will be added to image."
            //});

            await base.InstallAsync();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task UninstallAsync()
        {
            //settings
            await _settingService.DeleteSettingAsync<StoreDetailsSettings>();

            //locales
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.StoreDetails");

            await base.UninstallAsync();
        }

        /// <summary>
        /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
        /// </summary>
        public bool HideInWidgetList => false;
    }
}