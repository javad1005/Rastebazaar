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

        // Banner Name
        [NopResourceDisplayName("Plugins.Widgets.ColorBanner.BannerName")]
        [UIHint("Banner Name")]
        public string BannerName { get; set; }
        public bool BannerName_OverrideForStore { get; set; }

        // Background Color
        [NopResourceDisplayName("Plugins.Widgets.ColorBanner.BackgroundColor")]
        [UIHint("Background Color")]
        public string BackgroundColor { get; set; }
        public bool BackgroundColor_OverrideForStore { get; set; }

        // Picture
        [NopResourceDisplayName("Plugins.Widgets.ColorBanner.PictureUrl")]
        [UIHint("Picture Url")]
        public string PictureUrl { get; set; }
        public bool PictureUrl_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ColorBanner.PictureAlt")]
        [UIHint("Picture Alt")]
        public string PictureAlt { get; set; }
        public bool PictureAlt_OverrideForStore { get; set; }

        // Banner Titel
        [NopResourceDisplayName("Plugins.Widgets.ColorBanner.BannerTitel")]
        [UIHint("Banner Titel")]
        public string BannerTitel { get; set; }
        public bool BannerTitel_OverrideForStore { get; set; }

        // Banner Description
        [NopResourceDisplayName("Plugins.Widgets.ColorBanner.BannerDescription")]
        [UIHint("BannerDescription")]
        public string BannerDescription { get; set; }
        public bool BannerDescription_OverrideForStore { get; set; }

        // Button Content 
        [NopResourceDisplayName("Plugins.Widgets.ColorBanner.Button Content")]
        [UIHint("ButtonContent")]
        public string ButtonContent { get; set; }
        public bool ButtonContent_OverrideForStore { get; set; }

        // ....
    }
}
