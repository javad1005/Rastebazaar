using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Discounts;
using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.RasteBazars;

namespace Nop.Services.Catalog
{
    public partial interface IRasteBazarService
    {
        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="rasteBazar">RasteBazar</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteRasteBazarAsync(RasteBazar rasteBazar);

        /// <summary>
        /// Gets all rasteBazars
        /// </summary>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rasteBazars
        /// </returns>
        Task<IList<RasteBazar>> GetAllRasteBazarsAsync(int storeId = 0, bool showHidden = false);

        /// <summary>
        /// Gets all rasteBazars
        /// </summary>
        /// <param name="rasteBazarName">Category name</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="overridePublished">
        /// null - process "Published" property according to "showHidden" parameter
        /// true - load only "Published" products
        /// false - load only "Unpublished" products
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rasteBazar
        /// </returns>
        Task<IPagedList<RasteBazar>> GetAllRasteBazarsAsync(string rasteBazarName,
            int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets a rasteBazar
        /// </summary>
        /// <param name="categoryId">RasteBazar identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rasteBazar
        /// </returns>
        Task<RasteBazar> GetRasteBazarByIdAsync(int rasteBazarId);

        /// <summary>
        /// Inserts rasteBazar
        /// </summary>
        /// <param name="rasteBazar">RasteBazar</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertRasteBazarAsync(RasteBazar rasteBazar);

        /// <summary>
        /// Updates the rasteBazar
        /// </summary>
        /// <param name="rasteBazar">RasteBazar</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateRasteBazarAsync(RasteBazar rasteBazar);

        /// <summary>
        /// Delete a list of rasteBazars
        /// </summary>
        /// <param name="rasteBazars">RasteBazars</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteRasteBazarsAsync(IList<RasteBazar> rasteBazars);

        /// <summary>
        /// Returns a list of names of not existing rasteBazars
        /// </summary>
        /// <param name="rasteBazarIdsNames">The names and/or IDs of the rasteBazars to check</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of names and/or IDs not existing rasteBazars
        /// </returns>
        Task<string[]> GetNotExistingRasteBazarsAsync(string[] rasteBazarIdsNames);

        /// <summary>
        /// Gets rasteBazars by identifier
        /// </summary>
        /// <param name="rasteBazarIds">RasteBazar identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rasteBazars
        /// </returns>
        Task<IList<RasteBazar>> GetRasteBazarsByIdsAsync(int[] rasteBazarIds);
    
    }
}
