using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a category search model
    /// </summary>
    public partial record RasteBazarSearchModel : BaseSearchModel
    {
        #region Ctor

        public RasteBazarSearchModel()
        {

        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Catalog.RasteBazar.List.SearchRasteBazarName")]
        public string SearchRasteBazarName { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazar.List.SearchRasteBazarTitel")]
        public string SearchRasteBazarTitel { get; set; }

        [NopResourceDisplayName("Admin.Catalog.RasteBazar.List.SearchRasteBazarDescription")]
        public string SearchRasteBazarDescription { get; set; }

        #endregion

    }
}
