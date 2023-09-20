using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.StoreDetails.Models
{
    public record ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        // Secure Payment
        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.SecurePaymentTitel")]
        [UIHint("Secure Payment Titel")]
        public string SecurePaymentTitel { get; set; }
        public bool SecurePaymentTitel_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.SecurePaymentDescription")]
        [UIHint("Secure Payment Description")]
        public string SecurePaymentDescription { get; set; }
        public bool SecurePaymentDescription_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.SecurePaymentHiden")]
        [UIHint("Secure Payment Hiden")]
        public bool SecurePaymentHiden { get; set; }
        public bool SecurePaymentHiden_OverrideForStore { get; set; }

        // Free Shipping
        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.FreeShippingTitel")]
        [UIHint("Free Shipping Titel")]
        public string FreeShippingTitel { get; set; }
        public bool FreeShippingTitel_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.FreeShippingDescription")]
        [UIHint("Free Shipping Description")]
        public string FreeShippingDescription { get; set; }
        public bool FreeShippingDescription_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.FreeShippingHiden")]
        [UIHint("Free Shipping Hiden")]
        public bool FreeShippingHiden { get; set; }
        public bool FreeShippingHiden_OverrideForStore { get; set; }

        // Mony Back Guarantee
        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.MoneyBackGuaranteeTitel")]
        [UIHint("Money Back Guarantee Titel")]
        public string MoneyBackGuaranteeTitel { get; set; }
        public bool MoneyBackGuaranteeTitel_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.MoneyBackGuaranteeDesciption")]
        [UIHint("Money Back Guarantee Desciption")]
        public string MoneyBackGuaranteeDesciption { get; set; }
        public bool MoneyBackGuaranteeDesciption_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.MoneyBackGuaranteeHiden")]
        [UIHint("Money Back Guarantee Hiden")]
        public bool MoneyBackGuaranteeHiden { get; set; }
        public bool MoneyBackGuaranteeHiden_OverrideForStore { get; set; }

        // Full Time Support
        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.FullTimeSupportTitel")]
        [UIHint("Full Time Support Titel")]
        public string FullTimeSupportTitel { get; set; }
        public bool FullTimeSupportTitel_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.FullTimeSupportDescription")]
        [UIHint("Full Time Support Description")]
        public string FullTimeSupportDescription { get; set; }
        public bool FullTimeSupportDescription_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.FullTimeSupportHiden")]
        [UIHint("Full Time Support Hiden")]
        public bool FullTimeSupportHiden { get; set; }
        public bool FullTimeSupportHiden_OverrideForStore { get; set; }

        // Orginal Item Gurantee
        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.OrginalItemGuranteeTitel")]
        [UIHint("Orginal Item Gurantee Titel")]
        public string OrginalItemGuranteeTitel { get; set; }
        public bool OrginalItemGuranteeTitel_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.OrginalItemGuranteeDescription")]
        [UIHint("Orginal Item Gurantee Description")]
        public string OrginalItemGuranteeDescription { get; set; }
        public bool OrginalItemGuranteeDescription_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.StoreDetails.OrginalItemGuranteeHiden")]
        [UIHint("Orginal Item Gurantee Hiden")]
        public bool OrginalItemGuranteeHiden { get; set; }
        public bool OrginalItemGuranteeHiden_OverrideForStore { get; set; }

        // ....
    }
}
