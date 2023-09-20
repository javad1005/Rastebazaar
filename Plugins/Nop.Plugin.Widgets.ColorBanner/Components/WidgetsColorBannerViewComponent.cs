using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.ColorBanner;
using Nop.Plugin.Widgets.ColorBanner.Models;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.NivoSlider.Components
{
    public class WidgetsColorBannerViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly IWebHelper _webHelper;

        public WidgetsColorBannerViewComponent(IStoreContext storeContext, 
            IStaticCacheManager staticCacheManager, 
            ISettingService settingService, 
            IPictureService pictureService,
            IWebHelper webHelper)
        {
            _storeContext = storeContext;
            _staticCacheManager = staticCacheManager;
            _settingService = settingService;
            _pictureService = pictureService;
            _webHelper = webHelper;
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            var nivoSliderSettings = await _settingService.LoadSettingAsync<ColorBannerSettings>(store.Id);

            var model = new ColorBannerModel
            {
                
            };

            //if (string.IsNullOrEmpty(model.Picture1Url) && string.IsNullOrEmpty(model.Picture2Url) &&
            //    string.IsNullOrEmpty(model.Picture3Url) && string.IsNullOrEmpty(model.Picture4Url) &&
            //    string.IsNullOrEmpty(model.Picture5Url))
            //    //no pictures uploaded
            //    return Content("");

            return View("~/Plugins/Widgets.NivoSlider/Views/PublicInfo.cshtml", model);
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        //protected async Task<string> GetPictureUrlAsync(int pictureId)
        //{
        //    var cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(ModelCacheEventConsumer.PICTURE_URL_MODEL_KEY, 
        //        pictureId, _webHelper.IsCurrentConnectionSecured() ? Uri.UriSchemeHttps : Uri.UriSchemeHttp);

        //    return await _staticCacheManager.GetAsync(cacheKey, async () =>
        //    {
        //        //little hack here. nulls aren't cacheable so set it to ""
        //        var url = await _pictureService.GetPictureUrlAsync(pictureId, showDefaultPicture: false) ?? "";
        //        return url;
        //    });
        //}
    }
}
