using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Xoqal.Core.Models;
using Xoqal.Core.Query;
using Xoqal.Data.Relational.EF6.Linq;

namespace Xoqal.Data.Relational.EF6
{
    public class Repository<TAggregate,TKey> : IRepository<TAggregate,TKey> where TAggregate : class, IAggregate<TKey>, new()
    {
        private readonly DbContext _context;

        //public Repository(UnitOfWork unitOfWork)
        //{
        //    this._context = unitOfWork.Context;
        //}

        public Repository(DbContext context)
        {
            this._context = context;
        }

        public virtual DbSet<TAggregate> DbSet
        {
            get { return this._context.Set<TAggregate>(); }
        }

        public IQueryable<TAggregate> Query
        {
            get { return this.DbSet.AsQueryable(); }
        }

        public IEnumerable<TAggregate> GetAllItems()
        {
            return this.Query;
        }

        public IEnumerable<TAggregate> GetItems(int startIndex, int itemCount, SortDescription[] sortDescriptions = null)
        {
            return this.Query.ToPage(startIndex, itemCount, sortDescriptions);
        }

        public int GetItemCount()
        {
            return this.Query.Count();
        }

        public TAggregate GetItemByKey(TKey id)
        {
            return this.DbSet.FirstOrDefault(q => q.Id.Equals(id));
        }

        public void Add(TAggregate aggregate)
        {
            this.DbSet.Add(aggregate);
        }

        public void Update(TAggregate aggregate)
        {
            var entry = this._context.Entry(aggregate);

            if (entry.State == EntityState.Detached)
                this.DbSet.Attach(aggregate);
            
            entry.State = EntityState.Modified;
        }

        public void Remove(TAggregate aggregate)
        {
            var entry = this._context.Entry(aggregate);

            if (entry.State == EntityState.Added)
            {
                entry.State = EntityState.Detached;
                return;
            }

            if (entry.State == EntityState.Detached)
                this._context.Set<TAggregate>().Attach(aggregate);

            this.DbSet.Remove(aggregate);
        }

        public void Delete(TKey id)
        {
            var entry = new TAggregate {Id = id};

            this._context.Set<TAggregate>().Attach(entry);
            this._context.Set<TAggregate>().Remove(entry);
        }

        public void Delete(TAggregate aggregate)
        {
            throw new NotImplementedException();
        }
       
    }
}
