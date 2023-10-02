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
using Nop.Plugin.Payments.CardByCard.Models;
using Nop.Plugin.Payment.CardByCard.Models;

namespace Nop.Plugin.Payments.CardByCard.Components
{
    public class WidgetsCardByCardViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;

        public WidgetsCardByCardViewComponent(IStoreContext storeContext, ISettingService settingService)
        {
            _settingService = settingService;
            _storeContext = storeContext;
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            var settings = await _settingService.LoadSettingAsync<CardByCardSettings>(store.Id);

            var model = new CardByCardModel
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
                Description = settings.Description
            };
            if (model == null || String.IsNullOrEmpty(model.AccountNumber1) &&
                String.IsNullOrEmpty(model.AccountNumber2))
            {
                // If model was null or all detail was hiden so return empty
                return Content("");
            }
            return View("~/Plugins/Payment.CardByCard/Views/CardByCard.cshtml", model);
        }
    }
}
