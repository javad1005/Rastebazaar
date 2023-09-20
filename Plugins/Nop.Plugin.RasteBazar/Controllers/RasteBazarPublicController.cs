using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework;
using Microsoft.AspNetCore.Authorization;

namespace Nop.Plugin.RasteBazar.Controllers
{
    // permision not set
    [AutoValidateAntiforgeryToken]
    public class RasteBazarPublicController : BasePublicController
    {
        #region Filds



        #endregion

        #region Ctor

        public RasteBazarPublicController()
        {

        }

        #endregion

        #region Methods

        public async Task<IActionResult> DashBord()
        {
            return View("~/Plugins/RasteBazar/Views/Pages/Dashbord.cshtml");
        }

        public async Task<IActionResult> AboutStore()
        {
            return View("~/Plugins/RasteBazar/Views/Pages/AboutStore.cshtml");
        }

        public async Task<IActionResult> Customers()
        {
            return View("~/Plugins/RasteBazar/Views/Pages/Customers.cshtml");
        }

        public async Task<IActionResult> Factor()
        {
            return View("~/Plugins/RasteBazar/Views/Pages/Factor.cshtml");
        }

        public async Task<IActionResult> Products()
        {
            return View("~/Plugins/RasteBazar/Views/Pages/Products.cshtml");
        }

        public async Task<IActionResult> Reports()
        {
            return View("~/Plugins/RasteBazar/Views/Pages/Reports.cshtml");
        }

        public async Task<IActionResult> Settings()
        {
            return View("~/Plugins/RasteBazar/Views/Pages/Settings.cshtml");
        }

        #endregion
    }
}
