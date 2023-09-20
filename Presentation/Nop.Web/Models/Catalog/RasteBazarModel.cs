using Nop.Web.Framework.Models;
using Nop.Web.Models.Media;

namespace Nop.Web.Models.Catalog
{
    public partial record RasteBazarModel : BaseNopEntityModel
    {
        public RasteBazarModel()
        {
            PictureModel = new PictureModel();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaTitle { get; set; }

        public PictureModel PictureModel { get; set; }


    }
}
