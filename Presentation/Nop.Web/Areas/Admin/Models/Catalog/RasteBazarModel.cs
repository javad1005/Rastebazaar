using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a rastebazar model
    /// </summary>
    public partial record RasteBazarModel : BaseNopEntityModel, IAclSupportedModel, 
        ILocalizedModel<RasteBazarLocalizedModel>, IStoreMappingSupportedModel
    {
        #region Ctor

        public RasteBazarModel()
        {
            if (PageSize < 1)
            {
                PageSize = 5;
            }

            SelectedCustomerRoleIds = new List<int>();
            AvailableCustomerRoles = new List<SelectListItem>();
            SelectedStoreIds = new List<int>();
            AvailableStores = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.Name")]
        public string Name { get; set; }
          
        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.MetaKeywords")]
        public string MetaKeywords { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.MetaTitle")]
        public string MetaTitle { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.Title")]
        public string Title { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.SeName")]
        public string SeName { get; set; }

        [UIHint("Picture")]
        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.Picture")]
        public int PictureId { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.PageSize")]
        public int PageSize { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.Deleted")]
        public bool Deleted { get; set; }

        public IList<RasteBazarLocalizedModel> Locales { get; set; }

        //store mapping
        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.LimitedToStores")]
        public IList<int> SelectedStoreIds { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        //ACL (customer roles)
        [NopResourceDisplayName("Admin.Catalog.RasteBazar.Fields.AclCustomerRoles")]
        public IList<int> SelectedCustomerRoleIds { get; set; }
        public IList<SelectListItem> AvailableCustomerRoles { get; set; }

        #endregion

    }

    public partial record RasteBazarLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.Title")]
        public string Title { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.MetaKeywords")]
        public string MetaKeywords { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.MetaDescription")]
        public string MetaDescription { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.MetaTitle")]
        public string MetaTitle { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazars.Fields.SeName")]
        public string SeName { get; set; }
    }
}
