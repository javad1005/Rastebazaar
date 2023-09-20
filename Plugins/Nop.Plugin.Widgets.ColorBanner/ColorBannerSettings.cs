using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.ColorBanner
{
    public class ColorBannerSettings : ISettings
    {
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public string PictureUrl { get; set; }
        public string PictureAlt { get; set; }
        public string BannerTitel { get; set; }
        public string BannerDescription { get; set; }
        public string ButtonContent { get; set; }
    }
}
