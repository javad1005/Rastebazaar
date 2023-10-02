using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Payment.CardByCard.Models
{
    public record CardByCardModel : BaseNopModel
    {
        public string AccountOwnerName1 { get; set; }
        public string AccountOwnerName2 { get; set; }

        public string AccountNumber1 { get; set; }
        public string AccountNumber2 { get; set; }

        public string ShabaNumber1 { get; set; }
        public string ShabaNumber2 { get; set; }

        public string BankName1 { get; set; }
        public string BankName2 { get; set; }

        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }

        public string TelegramId { get; set; }

        public string InstagramId { get; set; }

        public string Description { get; set; }
    }
}
