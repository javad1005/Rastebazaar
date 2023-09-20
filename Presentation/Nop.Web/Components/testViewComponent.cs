using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;
using Nop.Web.Infrastructure.Cache;

namespace Nop.Web.Components
{
    public class testViewComponent : NopViewComponent
    {
        public testViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(int? productThumbPictureSize)
        {
            return View("HomepageMostedViewed");
        }
    }
}
