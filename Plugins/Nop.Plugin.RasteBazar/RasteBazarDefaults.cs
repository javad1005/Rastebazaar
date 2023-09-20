using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.RasteBazar
{
    /// <summary>
    /// Represents plugin constants
    /// </summary>
    public class RasteBazarDefaults
    {
        /// <summary>
        /// Gets the plugin system name
        /// </summary>
        public static string SystemName => "Rastebazar";

        /// <summary>
        /// Gets the user agent used to request third-party services
        /// </summary>
        public static string UserAgent => $"nopCommerce-{NopVersion.CURRENT_VERSION}";

        /// <summary>
        /// Gets the nopCommerce partner code
        /// </summary>
        public static string PartnerCode => "NopCommerce_PPCP";

        /// <summary>
        /// Gets the configuration route name
        /// </summary>
        public static string ConfigurationRouteName => "Plugin.RasteBazar.Configure";

        /// <summary>
        /// Gets the Dashbord route name
        /// </summary>
        public static string DashbordRouteName => "Plugin.RasteBazar.Dashbord";

        /// <summary>
        /// Gets the AboutStore route name
        /// </summary>
        public static string AboutStoreRouteName => "Plugin.RasteBazar.AboutStore";

        /// <summary>
        /// Gets the Customers route name
        /// </summary>
        public static string CustomersRouteName => "Plugin.RasteBazar.Customers";

        /// <summary>
        /// Gets the Factor route name
        /// </summary>
        public static string FactorRouteName => "Plugin.RasteBazar.Factor";

        /// <summary>
        /// Gets the Items route name
        /// </summary>
        public static string ProductsRouteName => "Plugin.RasteBazar.Products";

        /// <summary>
        /// Gets the Reports route name
        /// </summary>
        public static string ReportsRouteName => "Plugin.RasteBazar.Reports";

        /// <summary>
        /// Gets the Settings route name
        /// </summary>
        public static string SettingsRouteName => "Plugin.RasteBazar.Settings";

        /// <summary>
        /// Gets the one page checkout route name
        /// </summary>
        public static string OnePageCheckoutRouteName => "CheckoutOnePage";

        /// <summary>
        /// Gets the shopping cart route name
        /// </summary>
        public static string ShoppingCartRouteName => "ShoppingCart";

        /// <summary>
        /// Gets the session key to get process payment request
        /// </summary>
        public static string PaymentRequestSessionKey => "OrderPaymentInfo";

        /// <summary>
        /// Gets the name of a generic attribute to store the refund identifier
        /// </summary>
        public static string RefundIdAttributeName => "PayPalCommerceRefundId";

        /// <summary>
        /// Gets the path of Products.css file
        /// </summary>
        public static string ProductsCssResource => "~/Plugins/RasteBazar/Content/Products.css";

        /// <summary>
        /// Gets the path of Products.js file
        /// </summary>
        public static string ProductsScriptResource => "~/Plugins/RasteBazar/Scripts/Products.js";

        /// <summary>
        /// Gets the path of BaseScript.js file
        /// </summary>
        public static string BaseScriptScriptResource => "~/Plugins/RasteBazar/Scripts/BaseScript.js";

        /// <summary>
        /// Gets the path of Customers.js file
        /// </summary>
        public static string CustomersScriptResource => "~/Plugins/RasteBazar/Scripts/Customers.jsx";

        /// <summary>
        /// Gets the link of react.development.js file
        /// </summary>
        public static string ReactOnlineScript1Resource => "https://unpkg.com/react@17/umd/react.development.js";

        /// <summary>
        /// Gets the link of react-dom.development.js file
        /// </summary>
        public static string ReactOnlineScript2Resource => "https://unpkg.com/react-dom@17/umd/react-dom.development.js";

        /// <summary>
        /// Gets the link of babel.min.js file
        /// </summary>
        public static string ReactOnlineScript3Resource => "https://unpkg.com/@babel/standalone/babel.min.js";

        /// <summary>
        /// Gets a default period (in seconds) before the request times out
        /// </summary>
        public static int RequestTimeout => 10;

    }
}
