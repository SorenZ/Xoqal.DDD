﻿using System;
using System.Data;
using System.Data.Entity;

using Xoqal.Core.Models;

namespace Xoqal.Data.Relational.EF6
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext context)
        {
            this._context = context;
        }

        private readonly DbContext _context;

        public IRepository<TAggregate, TKey> Repository<TAggregate, TKey>() 
            where TAggregate : class, IAggregate<TKey>, new()
        {
            return new Repository<TAggregate, TKey>(this._context);
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }

        public void RollBack()
        {
            foreach (var entity in this._context.ChangeTracker.Entries())
            {
                if (entity.State == EntityState.Added)
                {
                    entity.State = EntityState.Detached;
                }

                if (entity.State == EntityState.Deleted || entity.State == EntityState.Modified)
                {
                    entity.State = EntityState.Unchanged;
                }
            }
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this._context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
