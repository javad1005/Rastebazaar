using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.ColorBanner;
using Nop.Plugin.Widgets.StoreDetails.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.StoreDetails.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class WidgetsColorBannerController : BasePluginController
    {
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IPictureService _pictureService;

        public WidgetsColorBannerController(ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService, 
            ISettingService settingService,
            IStoreContext storeContext,
            IPictureService pictureService)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
            _pictureService = pictureService;
        }

        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<ColorBannerSettings>(storeScope);
            var model = new ConfigurationModel
            {
                BannerName = settings.BannerTitel,
                BackgroundColor = settings.BackgroundColor,
                BannerTitel = settings.BannerTitel,
                BannerDescription = settings.BannerDescription,
                PictureId = settings.PictureId,
                PictureAlt = settings.PictureAlt,
                ButtonContent = settings.ButtonContent,
                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                model.BannerName_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.BannerName, storeScope);
                model.BannerTitel_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.BannerTitel, storeScope);
                model.BannerDescription_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.BannerDescription, storeScope);
                model.BackgroundColor_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.BackgroundColor, storeScope);
                model.PictureId_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.PictureId, storeScope);
                model.PictureAlt_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.PictureAlt, storeScope);
                model.ButtonContent_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.ButtonContent, storeScope);
            }

            return View("~/Plugins/Widgets.ColorBanner/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<ColorBannerSettings>(storeScope);

            settings.BannerName = model.BannerName;
            settings.BannerTitel = model.BannerTitel;
            settings.BannerDescription = model.BannerDescription;
            settings.BackgroundColor = model.BackgroundColor;
            settings.PictureId = model.PictureId;
            settings.PictureAlt = model.PictureAlt;
            settings.ButtonContent = model.ButtonContent;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BannerName, model.BannerName_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BannerTitel, model.BannerTitel_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BannerDescription, model.BannerDescription_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BackgroundColor, model.BackgroundColor_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.PictureId, model.PictureId_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.PictureAlt, model.PictureAlt_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.ButtonContent, model.ButtonContent_OverrideForStore, storeScope, false);

            //delete an old picture (if deleted or updated)
            var previousPicture = await _pictureService.GetPictureByIdAsync(settings.PictureId);
            if (previousPicture != null)
                await _pictureService.DeletePictureAsync(previousPicture);

            //now clear settings cache
            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));
            
            return await Configure();
        }
    }
}