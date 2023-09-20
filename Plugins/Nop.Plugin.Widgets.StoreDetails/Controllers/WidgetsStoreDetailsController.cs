using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
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
    public class WidgetsStoreDetailsController : BasePluginController
    {
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        public WidgetsStoreDetailsController(ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService, 
            ISettingService settingService,
            IStoreContext storeContext)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
        }

        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var storeDetailsSettings = await _settingService.LoadSettingAsync<StoreDetailsSettings>(storeScope);
            var model = new ConfigurationModel
            {
                SecurePaymentTitel = storeDetailsSettings.SecurePaymentTitel,
                SecurePaymentDescription = storeDetailsSettings.SecurePaymentDescription,
                SecurePaymentHiden = storeDetailsSettings.SecurePaymentHiden,

                FreeShippingTitel = storeDetailsSettings.FreeShippingTitel,
                FreeShippingDescription = storeDetailsSettings.FreeShippingDescription,
                FreeShippingHiden = storeDetailsSettings.FreeShippingHiden,

                MoneyBackGuaranteeTitel = storeDetailsSettings.MoneyBackGuaranteeTitel,
                MoneyBackGuaranteeDesciption = storeDetailsSettings.MoneyBackGuaranteeDesciption,
                MoneyBackGuaranteeHiden = storeDetailsSettings.MoneyBackGuaranteeHiden,

                FullTimeSupportTitel = storeDetailsSettings.FullTimeSupportTitel,
                FullTimeSupportDescription = storeDetailsSettings.FullTimeSupportDescription,
                FullTimeSupportHiden = storeDetailsSettings.FullTimeSupportHiden,

                OrginalItemGuranteeTitel = storeDetailsSettings.MoneyBackGuaranteeTitel,
                OrginalItemGuranteeDescription = storeDetailsSettings.OrginalItemGuranteeDescription,
                OrginalItemGuranteeHiden = storeDetailsSettings.OrginalItemGuranteeHiden,

                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                model.SecurePaymentTitel_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.SecurePaymentTitel, storeScope);
                model.SecurePaymentDescription_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.SecurePaymentDescription, storeScope);
                model.SecurePaymentHiden_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.SecurePaymentHiden, storeScope);

                model.FreeShippingTitel_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.FreeShippingTitel, storeScope);
                model.FreeShippingDescription_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.FreeShippingDescription, storeScope);
                model.FreeShippingHiden_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.FreeShippingHiden, storeScope);

                model.MoneyBackGuaranteeTitel_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.MoneyBackGuaranteeTitel, storeScope);
                model.MoneyBackGuaranteeDesciption_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.MoneyBackGuaranteeDesciption, storeScope);
                model.MoneyBackGuaranteeHiden_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.MoneyBackGuaranteeHiden, storeScope);

                model.FullTimeSupportTitel_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.FullTimeSupportTitel, storeScope);
                model.FullTimeSupportDescription_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.FullTimeSupportDescription, storeScope);
                model.FullTimeSupportHiden_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.FullTimeSupportHiden, storeScope);

                model.OrginalItemGuranteeTitel_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.OrginalItemGuranteeTitel, storeScope);
                model.OrginalItemGuranteeDescription_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.OrginalItemGuranteeDescription, storeScope);
                model.OrginalItemGuranteeHiden_OverrideForStore = await _settingService.SettingExistsAsync(storeDetailsSettings, x => x.OrginalItemGuranteeHiden, storeScope);

            }

            return View("~/Plugins/Widgets.StoreDetails/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var storeDetailsSettings = await _settingService.LoadSettingAsync<StoreDetailsSettings>(storeScope);

            storeDetailsSettings.SecurePaymentTitel = model.SecurePaymentTitel;
            storeDetailsSettings.SecurePaymentDescription = model.SecurePaymentDescription;
            storeDetailsSettings.SecurePaymentHiden = model.SecurePaymentHiden;

            storeDetailsSettings.FreeShippingTitel = model.FreeShippingTitel;
            storeDetailsSettings.FreeShippingDescription = model.FreeShippingDescription;
            storeDetailsSettings.FreeShippingHiden = model.FreeShippingHiden;

            storeDetailsSettings.MoneyBackGuaranteeTitel = model.MoneyBackGuaranteeTitel;
            storeDetailsSettings.MoneyBackGuaranteeDesciption = model.MoneyBackGuaranteeDesciption;
            storeDetailsSettings.MoneyBackGuaranteeHiden = model.MoneyBackGuaranteeHiden;

            storeDetailsSettings.FullTimeSupportTitel = model.FullTimeSupportTitel;
            storeDetailsSettings.FullTimeSupportDescription = model.FullTimeSupportDescription;
            storeDetailsSettings.FullTimeSupportHiden = model.FullTimeSupportHiden;

            storeDetailsSettings.OrginalItemGuranteeTitel = model.OrginalItemGuranteeTitel;
            storeDetailsSettings.OrginalItemGuranteeDescription = model.OrginalItemGuranteeDescription;
            storeDetailsSettings.OrginalItemGuranteeHiden = model.OrginalItemGuranteeHiden;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.SecurePaymentTitel, model.SecurePaymentTitel_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.SecurePaymentDescription, model.SecurePaymentDescription_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.SecurePaymentHiden, model.SecurePaymentHiden_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.FreeShippingTitel, model.FreeShippingTitel_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.FreeShippingDescription, model.FreeShippingDescription_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.FreeShippingHiden, model.FreeShippingHiden_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.MoneyBackGuaranteeTitel, model.MoneyBackGuaranteeTitel_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.MoneyBackGuaranteeDesciption, model.MoneyBackGuaranteeDesciption_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.MoneyBackGuaranteeHiden, model.MoneyBackGuaranteeHiden_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.FullTimeSupportTitel, model.FullTimeSupportTitel_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.FullTimeSupportDescription, model.FullTimeSupportDescription_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.FullTimeSupportHiden, model.FullTimeSupportHiden_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.OrginalItemGuranteeTitel, model.OrginalItemGuranteeTitel_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.OrginalItemGuranteeDescription, model.OrginalItemGuranteeDescription_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(storeDetailsSettings, x => x.OrginalItemGuranteeHiden, model.OrginalItemGuranteeHiden_OverrideForStore, storeScope, false);

            //now clear settings cache
            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));
            
            return await Configure();
        }
    }
}