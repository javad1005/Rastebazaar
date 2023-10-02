using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Configuration;

namespace Nop.Plugin.Payments.CardByCard
{
    /// <summary>
    /// Represents plugin settings
    /// </summary>
    public class CardByCardSettings : ISettings
    {
        #region Card Detail
        /// <summary>
        /// نام مالک حساب
        /// </summary>
        public string AccountOwnerName1 { get; set; }
        public string AccountOwnerName2 { get; set; }

        /// <summary>
        /// شماره حساب
        /// </summary>
        public string AccountNumber1 { get; set; }
        public string AccountNumber2 { get; set; }

        /// <summary>
        /// شماره شبا
        /// </summary>
        public string ShabaNumber1 { get; set; }
        public string ShabaNumber2 { get; set; }

        /// <summary>
        /// نام بانک
        /// </summary>
        public string BankName1 { get; set; }
        public string BankName2 { get; set; }

        /// <summary>
        /// شماره تماس
        /// </summary>
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }

        /// <summary>
        /// آیدی تلگرام
        /// </summary>
        public string TelegramId { get; set; }

        /// <summary>
        /// آیدی اینستاگرام
        /// </summary>
        public string InstagramId { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Payment property

        /// <summary>
        /// Gets or sets payment transaction mode
        /// </summary>
        public TransactMode TransactMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to "additional fee" is specified as percentage. true - percentage, false - fixed value.
        /// </summary>
        public bool AdditionalFeePercentage { get; set; }

        /// <summary>
        /// Gets or sets an additional fee
        /// </summary>
        public decimal AdditionalFee { get; set; }

        #endregion

    }
}
