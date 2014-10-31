using System.Collections;
using System.Collections.Generic;

namespace Xoqal.Core.Query
{
    /// <summary>
    /// Represents a paginated data containing total rows count.
    /// </summary>
    public class Paginated<T> : IPaginated<T>
    {
        /// <summary>
        /// Create a new instance of the <see cref="Paginated{T}"/> class.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="totalRowsCount"></param>
        public Paginated(IEnumerable<T> data, int totalRowsCount)
        {
            this.Data = data;
            this.TotalRowsCount = totalRowsCount;
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public IEnumerable<T> Data { get; set; }

        /// <summary>
        /// Gets or sets the total number of data.
        /// </summary>
        public int TotalRowsCount { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        IEnumerable IPaginated.Data
        {
            get
            {
                return this.Data;
            }

            set
            {
                this.Data = (IEnumerable<T>)value;
            }
        }
    }
}
