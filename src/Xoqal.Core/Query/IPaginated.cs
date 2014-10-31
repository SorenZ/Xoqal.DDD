using System.Collections;
using System.Collections.Generic;

namespace Xoqal.Core.Query
{
    /// <summary>
    /// Represents a paginated data containing total rows count.
    /// </summary>
    public interface IPaginated
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        IEnumerable Data { get; set; }

        /// <summary>
        /// Gets the total number of data.
        /// </summary>
        int TotalRowsCount { get; set; }
    }

    /// <summary>
    /// Represents a paginated data containing total rows count.
    /// </summary>
    public interface IPaginated<T> : IPaginated
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        new IEnumerable<T> Data { get; set; }
    }
}
