using System.Collections.Generic;
using System.Linq;

using Xoqal.Core.Models;
using Xoqal.Core.Query;

namespace Xoqal.Data.Relational
{
    /// <summary>
    /// Represents a generic object repository.
    /// </summary>
    public interface IRepository<TAggregate, in TKey> where TAggregate : IAggregate<TKey>
    {

        /// <summary>
        /// Gets the query.
        /// </summary>
        IQueryable<TAggregate> Query { get; }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns> </returns>
        IEnumerable<TAggregate> GetAllItems();

        /// <summary>
        /// Gets paginated items supporting sorting.
        /// </summary>
        /// <param name="startIndex"> The start index. </param>
        /// <param name="itemCount"> The item count. </param>
        /// <param name="sortDescriptions"> The sort descriptions. </param>
        /// <returns> </returns>
        IEnumerable<TAggregate> GetItems(int startIndex, int itemCount, SortDescription[] sortDescriptions = null);

        /// <summary>
        /// Gets the item count.
        /// </summary>
        /// <returns> </returns>
        int GetItemCount();

        /// <summary>
        /// Gets an item by its key.
        /// </summary>
        /// <returns> </returns>
        TAggregate GetItemByKey(TKey id);

        /// <summary>
        /// Adds the specified Aggregate.
        /// </summary>
        /// <param name="aggregate"> The Aggregate. </param>
        void Add(TAggregate aggregate);

        /// <summary>
        /// Updates the specified Aggregate.
        /// </summary>
        /// <param name="aggregate"> The Aggregate. </param>
        void Update(TAggregate aggregate);

        /// <summary>
        /// Removes the specified Aggregate.
        /// </summary>
        /// <param name="aggregate"> The Aggregate. </param>
        void Remove(TAggregate aggregate);

        void Delete(TKey id);

        void Delete(TAggregate aggregate);
    }
}
