using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.ColorBanner.Models
{
    public record ColorBannerModel : BaseNopModel
    {
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public string PictureUrl { get; set; }
        public int PictureId { get; set; }
        public string PictureAlt { get; set; }
        public string BannerTitel { get; set; }
        public string BannerDescription { get; set; }
        public string ButtonContent { get; set; }
    }
}
