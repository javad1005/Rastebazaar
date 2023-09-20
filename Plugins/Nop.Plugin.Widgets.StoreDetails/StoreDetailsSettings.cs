using Nop.Core.Configuration;
using Npgsql.Replication.PgOutput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.StoreDetails
{
    public class StoreDetailsSettings : ISettings
    {
        // پرداخت امن
        public string SecurePaymentTitel { get; set; } 
        public string SecurePaymentDescription { get; set; }
        public bool SecurePaymentHiden { get; set; }

        // حمل رایگان
        public string FreeShippingTitel { get; set; }
        public string FreeShippingDescription { get; set; }
        public bool FreeShippingHiden { get; set; }

        // ضمانت بازگشت وجه

        public string MoneyBackGuaranteeTitel { get; set; }
        public string MoneyBackGuaranteeDesciption { get; set; }
        public bool MoneyBackGuaranteeHiden { get; set; }

        //پشتیبانی 24 ساعته

        public string FullTimeSupportTitel { get; set; }
        public string FullTimeSupportDescription { get; set; }
        public bool FullTimeSupportHiden { get; set; }

        //ضمانت اصالت کالا

        public string OrginalItemGuranteeTitel { get; set; }
        public string OrginalItemGuranteeDescription { get; set; }
        public bool OrginalItemGuranteeHiden { get; set; }

        // ....
    }
}
