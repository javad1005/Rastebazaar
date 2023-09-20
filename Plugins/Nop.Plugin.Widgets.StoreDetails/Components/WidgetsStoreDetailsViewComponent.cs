using Microsoft.AspNetCore.Mvc;
using Nop.Core.Caching;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.StoreDetails.Models;

namespace Nop.Plugin.Widgets.StoreDetails.Components
{
    public class WidgetsStoreDetailsViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;

        public WidgetsStoreDetailsViewComponent(IStoreContext storeContext, ISettingService settingService)
        {
            _settingService = settingService;
            _storeContext = storeContext;
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            var storeDetailsSettings = await _settingService.LoadSettingAsync<StoreDetailsSettings>(store.Id);

            var model = new StoreDetailModel
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

                OrginalItemGuranteeTitel = storeDetailsSettings.OrginalItemGuranteeTitel,
                OrginalItemGuranteeDescription = storeDetailsSettings.OrginalItemGuranteeDescription,
                OrginalItemGuranteeHiden = storeDetailsSettings.OrginalItemGuranteeHiden
            };
            if (model == null || model.SecurePaymentHiden &&
                model.FreeShippingHiden && model.MoneyBackGuaranteeHiden
                && model.FullTimeSupportHiden && model.OrginalItemGuranteeHiden)
            {
                // If model was null or all detail was hiden so return empty
                return Content("");
            }
            return View("~/Plugins/Widgets.StoreDetails/Views/StoreDetails.cshtml", model);
        }
    }
}
