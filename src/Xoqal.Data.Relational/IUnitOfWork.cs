﻿using System;
using System.Data;
using Xoqal.Core.Models;

namespace Xoqal.Data.Relational
{
    /// <summary>
    /// Represents a unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TAggregate, TKey> Repository<TAggregate, TKey>() where TAggregate : class, IAggregate<TKey>, new();

        /// <summary>
        /// Commits the works.
        /// </summary>
        void Commit();

        /// <summary>
        /// rolebacks the works.
        /// </summary>
        void RollBack();

        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
    }
}
