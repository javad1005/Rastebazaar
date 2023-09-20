using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.RasteBazars;
using Nop.Data;
using Nop.Services.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// RasteBazar service
    /// </summary>
    public partial class RasteBazarService : IRasteBazarService
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly IRepository<RasteBazar> _rasteBazarRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public RasteBazarService(IRepository<RasteBazar> rasteBazarRepository,
            ICustomerService customerService,
            IStaticCacheManager staticCacheManager,
            IWorkContext workContext)
        {
            _customerService = customerService;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
            _rasteBazarRepository = rasteBazarRepository;
        }

        #endregion

        #region Utilities

        #endregion

        #region Methods

        /// <summary>
        /// Delete rasteBazar
        /// </summary>
        /// <param name="rasteBazar">RasteBazar</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteRasteBazarAsync(RasteBazar rasteBazar)
        {
            await _rasteBazarRepository.DeleteAsync(rasteBazar);
        }

        /// <summary>
        /// Delete RasteBazars
        /// </summary>
        /// <param name="rasteBazars">RasteBazars</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteRasteBazarsAsync(IList<RasteBazar> rasteBazars)
        {
            if (rasteBazars == null)
                throw new ArgumentNullException(nameof(rasteBazars));

            foreach (var rasteBazar in rasteBazars)
                await DeleteRasteBazarAsync(rasteBazar);
        }

        /// <summary>
        /// Gets all rasteBazars
        /// </summary>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rasteBazars
        /// </returns>
        public virtual async Task<IList<RasteBazar>> GetAllRasteBazarsAsync(int storeId = 0, bool showHidden = false)
        {
            var key = _staticCacheManager.PrepareKeyForDefaultCache(NopCatalogDefaults.RasteBazarsAllCacheKey,
                storeId,
                await _customerService.GetCustomerRoleIdsAsync(await _workContext.GetCurrentCustomerAsync()),
                showHidden);

            var categories = await _staticCacheManager
                .GetAsync(key, async () => (await GetAllRasteBazarsAsync(string.Empty)).ToList());

            return categories;
        }

        /// <summary>
        /// Gets all rasteBazars
        /// </summary>
        /// <param name="rasteBazarName">RasteBazar name</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rasteBazarss
        /// </returns>
        public virtual async Task<IPagedList<RasteBazar>> GetAllRasteBazarsAsync(string rasteBazarName, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return await _rasteBazarRepository.GetAllPagedAsync(async query =>
            {
                if (!string.IsNullOrWhiteSpace(rasteBazarName))
                    query = query.Where(c => c.Name.Contains(rasteBazarName));

                query = query.Where(c => !c.Deleted);

                return query.OrderBy(c => c.Id);
            }, pageIndex, pageSize);
        }

        /// <summary>
        /// Returns a list of names of not existing rasteBazars
        /// </summary>
        /// <param name="rasteBazarIdsNames">The names and/or IDs of the rasteBazars to check</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of names and/or IDs not existing rasteBazars
        /// </returns>
        public virtual async Task<string[]> GetNotExistingRasteBazarsAsync(string[] rasteBazarIdsNames)
        {
            if (rasteBazarIdsNames == null)
                throw new ArgumentNullException(nameof(rasteBazarIdsNames));

            var query = _rasteBazarRepository.Table;
            var queryFilter = rasteBazarIdsNames.Distinct().ToArray();
            //filtering by name
            var filter = await query.Select(c => c.Name)
                .Where(c => queryFilter.Contains(c))
                .ToListAsync();

            queryFilter = queryFilter.Except(filter).ToArray();

            //if some names not found
            if (!queryFilter.Any())
                return queryFilter.ToArray();

            //filtering by IDs
            filter = await query.Select(c => c.Id.ToString())
                .Where(c => queryFilter.Contains(c))
                .ToListAsync();

            return queryFilter.Except(filter).ToArray();
        }

        /// <summary>
        /// Gets a rasteBazar
        /// </summary>
        /// <param name="rasteBazarId">RasteBazar identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rasteBazar
        /// </returns>
        public virtual async Task<RasteBazar> GetRasteBazarByIdAsync(int rasteBazarId)
        {
            return await _rasteBazarRepository.GetByIdAsync(rasteBazarId, cache => default);
        }

        /// <summary>
        /// Gets rasteBazars by identifier
        /// </summary>
        /// <param name="rasteBazarIds">RasteBazar identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rasteBazars
        /// </returns>
        public virtual async Task<IList<RasteBazar>> GetRasteBazarsByIdsAsync(int[] rasteBazarIds)
        {
            return await _rasteBazarRepository.GetByIdsAsync(rasteBazarIds, includeDeleted: false);
        }

        /// <summary>
        /// Inserts rasteBazar
        /// </summary>
        /// <param name="rasteBazar">RasteBazar</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertRasteBazarAsync(RasteBazar rasteBazar)
        {
            await _rasteBazarRepository.InsertAsync(rasteBazar);
        }

        /// <summary>
        /// Updates the rasteBazar
        /// </summary>
        /// <param name="rasteBazar">RasteBazar</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateRasteBazarAsync(RasteBazar rasteBazar)
        {
            if (rasteBazar == null)
                throw new ArgumentNullException(nameof(rasteBazar));

            await _rasteBazarRepository.UpdateAsync(rasteBazar);
        }

        #endregion
    }
}
