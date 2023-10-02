using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Plugin.TrackShipment.Models;
using Nop.Core.Caching;
using Nop.Services.Common;
using Nop.Services.Stores;
using Nop.Core.Infrastructure;

namespace Nop.Plugin.TrackShipment.Controllers
{
    [AutoValidateAntiforgeryToken]
    [AuthorizeAdmin] //confirms access to the admin panel
    [Area(AreaNames.Admin)] //specifies the area containing a controller or action
    public class TrackShipmentController : BasePluginController
    {
        #region Fields
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IPermissionService _permissionService;

        #endregion

        #region Ctor

        public TrackShipmentController(
            ILocalizationService localizationService,
            INotificationService notificationService,
            ISettingService settingService,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IPermissionService permissionService,
            IStoreService storeService,
            IWorkContext workContext)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _settingService = settingService;
            _storeContext = storeContext;
            _permissionService = permissionService;
        }

        #endregion

        #region Methods

        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePlugins))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var storeDetailsSettings = await _settingService.LoadSettingAsync<TrackShipmentSettings>(storeScope);
            var model = new ConfigurationModel {
                ActiveStoreScopeConfiguration = storeScope
            };
            if (storeScope > 0)
            {

            }
            return View("~/Plugins/TrackShipment/Views/Configure.cshtml", model);
        }

        [HttpPost, ActionName("Configure")]
        [FormValueRequired("save")]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePlugins))
                return AccessDeniedView();

            var storeId = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<TrackShipmentSettings>(storeId);

            await _settingService.SaveSettingAsync(settings, settings => settings.Key , clearCache: false);

            //now clear settings cache
            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("پلا گین با موفقیت تنظیم شد ."));

            return await Configure();
        }

        
    }

    #endregion
}