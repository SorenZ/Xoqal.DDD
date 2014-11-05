using System.Collections.Generic;
using System.Linq;

using Xoqal.Core.Models;
using Xoqal.Core.Query;

namespace Xoqal.Data.Relational
{
    /// <summary>
    /// Represents a generic object repository.
    /// </summary>
    public interface IRepository<TEntity, in TKey> where TEntity : IEntity<TKey>
    {
        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns> </returns>
        IEnumerable<TEntity> GetAllItems();

        /// <summary>
        /// Gets paginated items supporting sorting.
        /// </summary>
        /// <param name="startIndex"> The start index. </param>
        /// <param name="itemCount"> The item count. </param>
        /// <param name="sortDescriptions"> The sort descriptions. </param>
        /// <returns> </returns>
        IEnumerable<TEntity> GetItems(int startIndex, int itemCount, SortDescription[] sortDescriptions = null);

        /// <summary>
        /// Gets the item count.
        /// </summary>
        /// <returns> </returns>
        int GetItemCount();

        /// <summary>
        /// Gets an item by its key.
        /// </summary>
        /// <returns> </returns>
        object GetItemByKey(TKey id);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        void Add(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        void Update(TEntity entity);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        void Remove(TEntity entity);

        void InsertRange(IEnumerable<TEntity> entities);

        void InsertOrUpdateGraph(TEntity entity);

        void InsertGraphRange(IEnumerable<TEntity> entities);

        void Delete(TKey id);

        void Delete(TEntity entity);

        /// <summary>
        /// Gets the query.
        /// </summary>
        IQueryable<TEntity> Query { get; }
    }
}
