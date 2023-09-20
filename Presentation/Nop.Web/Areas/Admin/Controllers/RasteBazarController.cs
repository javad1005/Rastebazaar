using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.RasteBazars;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Services.ExportImport;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Stores;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class RasteBazarController : BaseAdminController
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly IAclService _aclService;
        private readonly IRasteBazarModelFactory _rasteBazarModelFactory;
        private readonly IPermissionService _permissionService;
        private readonly IRasteBazarService _rasteBazarService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly INotificationService _notificationService;
        private readonly IPictureService _pictureService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IWorkContext _workContext;
        private readonly IExportManager _exportManager;
        private readonly IImportManager _importManager;

        #endregion

        #region Ctor

        public RasteBazarController(IPermissionService permissionService,
            ICustomerService customerService,
            IAclService aclService,
            IRasteBazarModelFactory rasteBazarModelFactory,
            IRasteBazarService rasteBazarService,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            INotificationService notificationService,
            IPictureService pictureService,
            ICustomerActivityService customerActivityService,
            IUrlRecordService urlRecordService,
            IWorkContext workContext,
            IExportManager exportManager,
            IImportManager importManager)
        {
            _aclService = aclService;
            _customerActivityService = customerActivityService;
            _customerService = customerService;
            _exportManager = exportManager;
            _importManager = importManager;
            _localizationService = localizationService;
            _localizedEntityService = localizedEntityService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _pictureService = pictureService;
            _urlRecordService = urlRecordService;
            _workContext = workContext;
            _rasteBazarModelFactory = rasteBazarModelFactory;
            _rasteBazarService = rasteBazarService;
        }

        #endregion

        #region Utilities

        protected virtual async Task UpdateLocalesAsync(RasteBazar rasteBazar, RasteBazarModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(rasteBazar,
                    x => x.Name,
                    localized.Name,
                    localized.LanguageId);

                await _localizedEntityService.SaveLocalizedValueAsync(rasteBazar,
                    x => x.Description,
                    localized.Description,
                    localized.LanguageId);

                await _localizedEntityService.SaveLocalizedValueAsync(rasteBazar,
                    x => x.MetaKeywords,
                    localized.MetaKeywords,
                    localized.LanguageId);

                await _localizedEntityService.SaveLocalizedValueAsync(rasteBazar,
                    x => x.MetaTitle,
                    localized.MetaTitle,
                    localized.LanguageId);
            }
        }

        protected virtual async Task UpdatePictureSeoNamesAsync(RasteBazar rasteBazar)
        {
            var picture = await _pictureService.GetPictureByIdAsync(rasteBazar.PictureId);
            if (picture != null)
                await _pictureService.SetSeoFilenameAsync(picture.Id, await _pictureService.GetPictureSeNameAsync(rasteBazar.Name));
        }

        protected virtual async Task SaveRasteBazarAclAsync(RasteBazar rasteBazr, RasteBazarModel model)
        {
            rasteBazr.SubjectToAcl = model.SelectedCustomerRoleIds.Any();
            await _rasteBazarService.UpdateRasteBazarAsync(rasteBazr);

            var existingAclRecords = await _aclService.GetAclRecordsAsync(rasteBazr);
            var allCustomerRoles = await _customerService.GetAllCustomerRolesAsync(true);
            foreach (var customerRole in allCustomerRoles)
            {
                if (model.SelectedCustomerRoleIds.Contains(customerRole.Id))
                {
                    //new role
                    if (!existingAclRecords.Any(acl => acl.CustomerRoleId == customerRole.Id))
                        await _aclService.InsertAclRecordAsync(rasteBazr, customerRole.Id);
                }
                else
                {
                    //remove role
                    var aclRecordToDelete = existingAclRecords.FirstOrDefault(acl => acl.CustomerRoleId == customerRole.Id);
                    if (aclRecordToDelete != null)
                        await _aclService.DeleteAclRecordAsync(aclRecordToDelete);
                }
            }
        }

        #endregion

        #region List

        public virtual IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual async Task<IActionResult> List()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //prepare model sitemapNod
            var model = await _rasteBazarModelFactory.PrepareRasteBazarSearchModelAsync(new RasteBazarSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> List(RasteBazarSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _rasteBazarModelFactory.PrepareRasteBazarListModelAsync(searchModel);

            return Json(model);
        }


        #endregion

        #region Create / Edit / Delete

        public virtual async Task<IActionResult> Create()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //prepare model
            var model = await _rasteBazarModelFactory.PrepareRasteBazarModelAsync(new RasteBazarModel(), null);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual async Task<IActionResult> Create(RasteBazarModel model, bool continueEditing)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                var rasteBazar = model.ToEntity<RasteBazar>();
                rasteBazar.CreatedOnUtc = DateTime.UtcNow;
                rasteBazar.UpdatedOnUtc = DateTime.UtcNow;
                await _rasteBazarService.InsertRasteBazarAsync(rasteBazar);

                //locales
                await UpdateLocalesAsync(rasteBazar, model);

                await _rasteBazarService.UpdateRasteBazarAsync(rasteBazar);

                //update picture seo file name
                await UpdatePictureSeoNamesAsync(rasteBazar);

                //ACL (customer roles)
                await SaveRasteBazarAclAsync(rasteBazar, model);

                //activity log
                await _customerActivityService.InsertActivityAsync("AddNewRasteBazar",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewRasteBazar"), rasteBazar.Name), rasteBazar);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.RasteBazars.Added"));

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = rasteBazar.Id });
            }

            //prepare model
            model = await _rasteBazarModelFactory.PrepareRasteBazarModelAsync(model, null, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public virtual async Task<IActionResult> Edit(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a rastebazar with the specified id
            var rastebazar = await _rasteBazarService.GetRasteBazarByIdAsync(id);
            if (rastebazar == null || rastebazar.Deleted)
                return RedirectToAction("List");

            //prepare model
            var model = await _rasteBazarModelFactory.PrepareRasteBazarModelAsync(null, rastebazar);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual async Task<IActionResult> Edit(RasteBazarModel model, bool continueEditing)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a category with the specified id
            var rasteBazar = await _rasteBazarService.GetRasteBazarByIdAsync(model.Id);
            if (rasteBazar == null || rasteBazar.Deleted)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                var prevPictureId = rasteBazar.PictureId;

                rasteBazar = model.ToEntity(rasteBazar);
                rasteBazar.UpdatedOnUtc = DateTime.UtcNow;
                await _rasteBazarService.UpdateRasteBazarAsync(rasteBazar);

                //search engine name
                model.SeName = await _urlRecordService.ValidateSeNameAsync(rasteBazar, model.SeName, rasteBazar.Name, true);
                await _urlRecordService.SaveSlugAsync(rasteBazar, model.SeName, 0);

                //locales
                await UpdateLocalesAsync(rasteBazar, model);

                await _rasteBazarService.UpdateRasteBazarAsync(rasteBazar);

                //delete an old picture (if deleted or updated)
                if (prevPictureId > 0 && prevPictureId != rasteBazar.PictureId)
                {
                    var prevPicture = await _pictureService.GetPictureByIdAsync(prevPictureId);
                    if (prevPicture != null)
                        await _pictureService.DeletePictureAsync(prevPicture);
                }

                //update picture seo file name
                await UpdatePictureSeoNamesAsync(rasteBazar);

                //ACL
                await SaveRasteBazarAclAsync(rasteBazar, model);

                //activity log
                await _customerActivityService.InsertActivityAsync("EditRasteBazar",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditRasteBazar"), rasteBazar.Name), rasteBazar);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.RasteBazars.Updated"));

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = rasteBazar.Id });
            }

            //prepare model
            model = await _rasteBazarModelFactory.PrepareRasteBazarModelAsync(model, rasteBazar, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Delete(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //try to get a category with the specified id
            var category = await _rasteBazarService.GetRasteBazarByIdAsync(id);
            if (category == null)
                return RedirectToAction("List");

            await _rasteBazarService.DeleteRasteBazarAsync(category);

            //activity log
            await _customerActivityService.InsertActivityAsync("DeleteCategory",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteRasteBazar"), category.Name), category);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.RasteBazars.Deleted"));

            return RedirectToAction("List");
        }

        [HttpPost]
        public virtual async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            if (selectedIds == null || selectedIds.Count == 0)
                return NoContent();

            await _rasteBazarService.DeleteRasteBazarsAsync(await (await _rasteBazarService.GetRasteBazarsByIdsAsync(selectedIds.ToArray())).WhereAwait(async p => await _workContext.GetCurrentVendorAsync() == null).ToListAsync());

            return Json(new { Result = true });
        }

        #endregion

        #region Export / Import

        //این توابع باید اصلاح بشن
        public virtual async Task<IActionResult> ExportXml()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            try
            {
                var xml = await _exportManager.ExportCategoriesToXmlAsync();

                return File(Encoding.UTF8.GetBytes(xml), "application/xml", "categories.xml");
            }
            catch (Exception exc)
            {
                await _notificationService.ErrorNotificationAsync(exc);
                return RedirectToAction("List");
            }
        }

        public virtual async Task<IActionResult> ExportXlsx()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            try
            {
                var bytes = await _exportManager
                    .ExportRasteBazarsToXlsxAsync((await _rasteBazarService.GetAllRasteBazarsAsync(showHidden: true)).ToList());

                return File(bytes, MimeTypes.TextXlsx, "rastebazars.xlsx");
            }
            catch (Exception exc)
            {
                await _notificationService.ErrorNotificationAsync(exc);
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> ImportFromXlsx(IFormFile importexcelfile)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageCategories))
                return AccessDeniedView();

            //a vendor cannot import categories
            if (await _workContext.GetCurrentVendorAsync() != null)
                return AccessDeniedView();

            try
            {
                if (importexcelfile != null && importexcelfile.Length > 0)
                {
                    await _importManager.ImportCategoriesFromXlsxAsync(importexcelfile.OpenReadStream());
                }
                else
                {
                    _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Common.UploadFile"));
                    return RedirectToAction("List");
                }

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Catalog.Categories.Imported"));

                return RedirectToAction("List");
            }
            catch (Exception exc)
            {
                await _notificationService.ErrorNotificationAsync(exc);
                return RedirectToAction("List");
            }
        }

        #endregion

    }
    
}
