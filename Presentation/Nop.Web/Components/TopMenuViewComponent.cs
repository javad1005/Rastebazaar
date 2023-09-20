using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Web.Components
{
    public partial class TopMenuViewComponent : NopViewComponent
    {
        private readonly ICatalogModelFactory _catalogModelFactory;
        private readonly ICommonModelFactory _commonModelFactory;

        public TopMenuViewComponent(ICatalogModelFactory catalogModelFactory, ICommonModelFactory commonModelFactory)
        {
            _catalogModelFactory = catalogModelFactory;
            _commonModelFactory = commonModelFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? productThumbPictureSize)
        {
            var model = await _catalogModelFactory.PrepareTopMenuModelAsync();
            model.HeaderLinksModel = await _commonModelFactory.PrepareHeaderLinksModelAsync();
            return View(model);
        }
    }
}
