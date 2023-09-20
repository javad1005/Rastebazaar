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
using Nop.Plugin.RasteBazar.Models;
using Nop.Core.Caching;
using Nop.Services.Common;
using Nop.Services.Stores;
using Nop.Core.Infrastructure;

namespace Nop.Plugin.RasteBazar.Controllers
{
    [AutoValidateAntiforgeryToken]
    [AuthorizeAdmin] //confirms access to the admin panel
    [Area(AreaNames.Admin)] //specifies the area containing a controller or action
    public class RasteBazarController : BasePluginController
    {
        #region Fields
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        #endregion

        #region Ctor

        public RasteBazarController(
            ILocalizationService localizationService,
            INotificationService notificationService,
            ISettingService settingService,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IStoreService storeService,
            IWorkContext workContext)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _settingService = settingService;
            _storeContext = storeContext;
        }

        #endregion

        #region Methods

        public async Task<IActionResult> Configure()
        {
            ConfigurationModel model = new ConfigurationModel();
            return View("~/Plugins/RasteBazar/Views/Configure.cshtml", model);
        }

        [HttpPost, ActionName("Configure")]
        [FormValueRequired("save")]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
                return await Configure();

            var storeId = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var sendinblueSettings = await _settingService.LoadSettingAsync<RasteBazarSettings>(storeId);

            await _settingService.SaveSettingAsync(sendinblueSettings, settings => settings.IsActive , clearCache: false);

            //now clear settings cache
            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("پلا گین با موفقیت تنظیم شد ."));

            return await Configure();
        }

        
    }

    #endregion
}