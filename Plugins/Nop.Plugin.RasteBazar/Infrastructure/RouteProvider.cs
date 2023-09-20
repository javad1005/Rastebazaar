using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Infrastructure;

namespace Nop.Plugin.RasteBazar.Infrastructure
{
    /// <summary>
    /// Represents plugin route provider
    /// </summary>
    public class RouteProvider : BaseRouteProvider, IRouteProvider
    {
        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority => 0;

        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="endpointRouteBuilder">Route builder</param>
        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            var lang = GetLanguageRoutePattern();

            endpointRouteBuilder.MapControllerRoute(RasteBazarDefaults.DashbordRouteName,
               $"{lang}/Dashbord",
               new { controller = "RasteBazarPublic", action = "Dashbord" });

            endpointRouteBuilder.MapControllerRoute(RasteBazarDefaults.AboutStoreRouteName,
              $"{lang}/AboutStore_cu",
              new { controller = "RasteBazarPublic", action = "AboutStore" });

            endpointRouteBuilder.MapControllerRoute(RasteBazarDefaults.CustomersRouteName,
              $"{lang}/Customers_cu",
              new { controller = "RasteBazarPublic", action = "Customers" });

            endpointRouteBuilder.MapControllerRoute(RasteBazarDefaults.FactorRouteName,
              $"{lang}/Factor_cu",
              new { controller = "RasteBazarPublic", action = "Factor" });

            endpointRouteBuilder.MapControllerRoute(RasteBazarDefaults.ProductsRouteName,
              $"{lang}/Products_cu",
              new { controller = "RasteBazarPublic", action = "Products" });

            endpointRouteBuilder.MapControllerRoute(RasteBazarDefaults.ReportsRouteName,
              $"{lang}/Reports_cu",
              new { controller = "RasteBazarPublic", action = "Reports" });

            endpointRouteBuilder.MapControllerRoute(RasteBazarDefaults.SettingsRouteName,
              $"{lang}/Settings_cu",
              new { controller = "RasteBazarPublic", action = "Settings" });

        }
    }
}
