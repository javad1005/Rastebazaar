using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Payments.CardByCard.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Payments.CardByCard.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class CardByCardController : BasePluginController
    {
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        public CardByCardController(ILocalizationService localizationService,
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
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePlugins))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<CardByCardSettings>(storeScope);
            var model = new ConfigurationModel
            {
                AccountOwnerName1 = settings.AccountOwnerName1,
                AccountOwnerName2 = settings.AccountOwnerName2,

                AccountNumber1 = settings.AccountNumber1,
                AccountNumber2 = settings.AccountNumber2,

                ShabaNumber1 = settings.ShabaNumber1,
                ShabaNumber2 = settings.ShabaNumber2,

                BankName1 = settings.BankName1,
                BankName2 = settings.BankName2,

                PhoneNumber1 = settings.PhoneNumber1,
                PhoneNumber2 = settings.PhoneNumber2,

                TelegramId = settings.TelegramId,
                InstagramId = settings.InstagramId,
                Description = settings.Description,

                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                model.AccountOwnerName1_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.AccountOwnerName1, storeScope);
                model.AccountOwnerName2_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.AccountOwnerName2, storeScope);

                model.AccountNumber1_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.AccountNumber1, storeScope);
                model.AccountNumber2_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.AccountNumber2, storeScope);

                model.ShabaNumber1_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.ShabaNumber1, storeScope);
                model.ShabaNumber2_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.ShabaNumber2, storeScope);

                model.BankName1_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.BankName1, storeScope);
                model.BankName2_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.BankName2, storeScope);

                model.PhoneNumber1_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.PhoneNumber1, storeScope);
                model.PhoneNumber2_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.PhoneNumber2, storeScope);

                model.TelegramId_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.TelegramId, storeScope);
                model.InstagramId_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.InstagramId, storeScope);
                model.Description_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Description, storeScope);

            }

            return View("~/Plugins/Payment.CardByCard/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<CardByCardSettings>(storeScope);

            settings.AccountOwnerName1 = model.AccountOwnerName1;
            settings.AccountOwnerName2 = model.AccountOwnerName2;

            settings.AccountNumber1 = model.AccountNumber1;
            settings.AccountNumber2 = model.AccountNumber2;

            settings.ShabaNumber1 = model.ShabaNumber1;
            settings.ShabaNumber2 = model.ShabaNumber2;

            settings.BankName1 = model.BankName1;
            settings.BankName2 = model.BankName2;

            settings.PhoneNumber1 = model.PhoneNumber1;
            settings.PhoneNumber2 = model.PhoneNumber2;

            settings.TelegramId = model.TelegramId;
            settings.InstagramId = model.InstagramId;
            settings.Description = model.Description;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.AccountOwnerName1, model.AccountOwnerName1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.AccountOwnerName2, model.AccountOwnerName2_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.AccountNumber1, model.AccountNumber1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.AccountNumber2, model.AccountNumber2_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.ShabaNumber1, model.ShabaNumber1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.ShabaNumber2, model.ShabaNumber2_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BankName1, model.BankName1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BankName2, model.BankName2_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.PhoneNumber1, model.PhoneNumber1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.PhoneNumber2, model.PhoneNumber2_OverrideForStore, storeScope, false);

            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.TelegramId, model.TelegramId_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.InstagramId, model.InstagramId_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Description, model.Description_OverrideForStore, storeScope, false);

            //now clear settings cache
            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));
            
            return await Configure();
        }
    }
}