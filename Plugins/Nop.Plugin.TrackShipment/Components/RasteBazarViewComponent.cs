using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Nop.Web.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.EMMA;

namespace Nop.Plugin.RasteBazar.Components
{
    [ViewComponent(Name = "RasteBazarViewComponent")]
    public class RasteBazarViewComponent : NopViewComponent
    {
        #region Ctor

        public RasteBazarViewComponent() { }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the view component result
        /// </returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Plugins/RasteBazar/Views/PublicInfo.cshtml");
        }

        #endregion
    }
}
