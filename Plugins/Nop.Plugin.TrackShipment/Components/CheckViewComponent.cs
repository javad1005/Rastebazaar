using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.RasteBazar.Domains;
using Nop.Plugin.RasteBazar.Services;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.RasteBazar.Components
{
    /// <summary>
    /// Represents the view component to  info page
    /// </summary>
    public class CheckViewComponent : NopViewComponent
    {
        #region Fields

        private readonly ICheckService _checkService;

        #endregion

        public CheckViewComponent(
            ICheckService checkService)
        {
            _checkService = checkService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Setup the product to save
            var record = new Check
            {
                OwnerName = "testName",
                Amount = 1000
            };
            //Map the values we're interested in to our new entity
            _checkService.Log(record);

            return Content("");
        }
    }
}
