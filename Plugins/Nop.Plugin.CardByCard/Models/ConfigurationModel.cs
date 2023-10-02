using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Payments.CardByCard.Models
{
    /// <summary>
    /// Represents configuration model
    /// </summary>
    public record ConfigurationModel : BaseNopModel
    {
        #region Ctor

        public ConfigurationModel()
        {
        }

        #endregion

        #region Properties

        public bool IsConfigured { get; set; }

        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Payments.CardByCard.Fields.AccountOwnerName1")]
        [UIHint("Account Owner Name 1")]
        public string AccountOwnerName1 { get; set; }
        public bool AccountOwnerName1_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.CardByCard.Fields.AccountOwnerName2")]
        [UIHint("Account Owner Name 2")]
        public string AccountOwnerName2 { get; set; }
        public bool AccountOwnerName2_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.CardByCard.Fields.AccountNumber1")]
        [UIHint("Account Number 1")]
        public string AccountNumber1 { get; set; }
        public bool AccountNumber1_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.CardByCard.Fields.AccountNumber2")]
        [UIHint("Account Number 2")]
        public string AccountNumber2 { get; set; }
        public bool AccountNumber2_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.CardByCard.Fields.ShabaNumber1")]
        [UIHint("Shaba Number 1")]
        public string ShabaNumber1 { get; set; }
        public bool ShabaNumber1_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.CardByCard.Fields.ShabaNumber2")]
        [UIHint("Shaba Number 2")]
        public string ShabaNumber2 { get; set; }
        public bool ShabaNumber2_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.CardByCard.Fields.BankName1")]
        [UIHint("Bank Name 1")]
        public string BankName1 { get; set; }
        public bool BankName1_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.CardByCard.Fields.BankName2")]
        [UIHint("Bank Name 2")]
        public string BankName2 { get; set; }
        public bool BankName2_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.CardByCard.Fields.PhoneNumber 1")]
        [UIHint("Phone Number 1")]
        public string PhoneNumber1 { get; set; }
        public bool PhoneNumber1_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.CardByCard.Fields.PhoneNumber 2")]
        [UIHint("Phone Number 2")]
        public string PhoneNumber2 { get; set; }
        public bool PhoneNumber2_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.CardByCard.Fields.TelegramId")]
        [UIHint("Telegram Id")]
        public string TelegramId { get; set; }
        public bool TelegramId_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.CardByCard.Fields.InstagramId")]
        [UIHint("Instagram Id")]
        public string InstagramId { get; set; }
        public bool InstagramId_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.CardByCard.Fields.Description")]
        [UIHint("Description")]
        public string Description { get; set; }
        public bool Description_OverrideForStore { get; set; }

        #endregion
    }
}