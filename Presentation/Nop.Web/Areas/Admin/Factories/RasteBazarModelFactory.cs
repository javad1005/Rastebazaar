using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Discounts;
using Nop.Services.Catalog;
using Nop.Services.Directory;
using Nop.Services.Discounts;
using Nop.Services.Localization;
using Nop.Services.Seo;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Framework.Extensions;
using Nop.Web.Framework.Factories;
using Nop.Web.Framework.Models.Extensions;
using Nop.Core.Domain.RasteBazars;
using Nop.Web.Areas.Admin.Models.Catalog;
using System.Threading.Tasks;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the rastebazar model factory implementation
    /// </summary>
    public partial class RasteBazarModelFactory : IRasteBazarModelFactory
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly IAclSupportedModelFactory _aclSupportedModelFactory;
        private readonly IRasteBazarService _rasteBazarService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedModelFactory _localizedModelFactory;
        private readonly IUrlRecordService _urlRecordService;

        #endregion

        #region Ctor

        public RasteBazarModelFactory(CatalogSettings catalogSettings,
            IAclSupportedModelFactory aclSupportedModelFactory,
            ILocalizationService localizationService,
            ILocalizedModelFactory localizedModelFactory,
            IUrlRecordService urlRecordService)
        {
            _catalogSettings = catalogSettings;
            _aclSupportedModelFactory = aclSupportedModelFactory;
            _localizationService = localizationService;
            _localizedModelFactory = localizedModelFactory;
            _urlRecordService = urlRecordService;
        }

        #endregion

        #region Utilities


        #endregion

        #region Methods

        /// <summary>
        /// Prepare paged rastebazar list model
        /// </summary>
        /// <param name="searchModel">RasteBazar search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rastebazar list model
        /// </returns>
        public virtual async Task<RasteBazarListModel> PrepareRasteBazarListModelAsync(RasteBazarSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));
            //get rastebazars
            var rastebazars = await _rasteBazarService.GetAllRasteBazarsAsync(rasteBazarName: searchModel.SearchRasteBazarName,
                 pageSize: searchModel.PageSize);

            //prepare grid model
            var model = await new RasteBazarListModel().PrepareToGridAsync(searchModel, rastebazars, () =>
            {
                return rastebazars.SelectAwait(async rastebazar =>
                {
                    //fill in model values from the entity
                    var rastebazarModel = rastebazar.ToModel<RasteBazarModel>();

                    //fill in additional values (not existing in the entity)
                    rastebazarModel.SeName = await _urlRecordService.GetSeNameAsync(rastebazar, 0, true, false);

                    return rastebazarModel;
                });
            });

            return model;
        }

        public virtual async Task<RasteBazarModel> PrepareRasteBazarModelAsync(RasteBazarModel model, RasteBazar rasteBazar, bool excludeProperties = false)
        {
            Func<RasteBazarLocalizedModel, int, Task> localizedModelConfiguration = null;

            if (rasteBazar != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = rasteBazar.ToModel<RasteBazarModel>();
                    model.SeName = await _urlRecordService.GetSeNameAsync(rasteBazar, 0, true, false);
                }

                //define localized model configuration action
                localizedModelConfiguration = async (locale, languageId) =>
                {
                    locale.Name = await _localizationService.GetLocalizedAsync(rasteBazar, entity => entity.Name, languageId, false, false);
                    locale.Description = await _localizationService.GetLocalizedAsync(rasteBazar, entity => entity.Description, languageId, false, false);
                    locale.Title = await _localizationService.GetLocalizedAsync(rasteBazar, entity => entity.Title, languageId, false, false);
                    locale.MetaKeywords = await _localizationService.GetLocalizedAsync(rasteBazar, entity => entity.MetaKeywords, languageId, false, false);
                    locale.MetaTitle = await _localizationService.GetLocalizedAsync(rasteBazar, entity => entity.MetaTitle, languageId, false, false);
                    locale.SeName = await _urlRecordService.GetSeNameAsync(rasteBazar, languageId, false, false);
                };
            }

            //set default values for the new model
            if (rasteBazar == null)
            {
                model.PageSize = _catalogSettings.DefaultCategoryPageSize;
            }

            //prepare localized models
            if (!excludeProperties)
                model.Locales = await _localizedModelFactory.PrepareLocalizedModelsAsync(localizedModelConfiguration);

            //prepare model customer roles
            await _aclSupportedModelFactory.PrepareModelCustomerRolesAsync(model, rasteBazar, excludeProperties);

            return model;
        }

        /// <summary>
        /// Prepare rastebazar search model
        /// </summary>
        /// <param name="searchModel">RasteBazar search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rastebazar search model
        /// </returns>
        public virtual async Task<RasteBazarSearchModel> PrepareRasteBazarSearchModelAsync(RasteBazarSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare grid
            searchModel.SetGridPageSize();

            return searchModel;
        }

        #endregion
    }
}
