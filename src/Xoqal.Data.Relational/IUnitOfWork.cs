using System;
using System.Data;
using Xoqal.Core.Models;

namespace Xoqal.Data.Relational
{
    /// <summary>
    /// Represents a unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : IEntity<TKey>;

        /// <summary>
        /// Commits the works.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rolls the works.
        /// </summary>
        void RollBack();

        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
    }
}
