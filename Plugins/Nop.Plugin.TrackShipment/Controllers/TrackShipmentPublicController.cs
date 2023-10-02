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

namespace Nop.Plugin.TrackShipment.Controllers
{
    // permision not set
    [AutoValidateAntiforgeryToken]
    public class TrackShipmentPublicController : BasePublicController
    {
        #region Filds



        #endregion

        #region Ctor

        public TrackShipmentPublicController()
        {

        }

        #endregion

        #region Methods

        public async Task<IActionResult> DashBord()
        {
            return View("~/Plugins/RasteBazar/Views/Pages/Dashbord.cshtml");
        }

        #endregion
    }
}
