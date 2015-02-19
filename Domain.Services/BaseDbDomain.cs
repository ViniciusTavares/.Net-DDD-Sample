using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Config;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Models;
using Domain.Services.Contracts;
using Infrastructure.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace Domain.Services
{
    public class BaseDbDomain<TEntity> : IDisposable, IBaseDbDomain<TEntity> where TEntity : BaseEntity, new()
    {
        protected ApplicationDbContext Context;

        public BaseDbDomain(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> where = null, IOrderByClause<TEntity>[] orderBy = null, int skip = 0, int top = 0, string[] include = null, bool readOnly = false)
        {
            try
            {
                IQueryable<TEntity> data = Context.Set<TEntity>();

                if (readOnly)
                {
                    if (where != null)
                    {
                        data = data.Where(where).AsNoTracking();
                    }
                }
                else
                {
                    if (where != null)
                    {
                        data = data.Where(where);
                    }
                }

                if (orderBy != null)
                {
                    bool isFirstSort = true;

                    orderBy.ToList().ForEach(one =>
                    {
                        data = one.ApplySort(data, isFirstSort);
                        isFirstSort = false;
                    });
                }

                if (skip > 0)
                {
                    data = data.Skip(skip);
                }
                if (top > 0)
                {
                    data = data.Take(top);
                }

                if (include != null)
                {
                    include.ToList().ForEach(one => data = data.Include(one));
                }

                foreach (TEntity item in data)
                {
                    yield return item;
                }
            }
            finally
            {
            }
        }

        public virtual TEntity SelectById(long Id)
        {
            try
            {
                return this.Context.Set<TEntity>().Find(Id);
            }
            finally { }
        }

        public virtual TEntity Insert(TEntity item, bool saveImmediately = true)
        {
            try
            {
                DbSet<TEntity> set = Context.Set<TEntity>();

                set.Add(item);

                if (saveImmediately)
                {
                    Context.SaveChanges();
                }

                return item;
            }
            finally
            {
            }
        }

        public virtual void AddOrUpdate(TEntity item, bool saveImmediately = true)
        {
            var entry = Context.Entry(item);

            if (entry != null)
            {
                entry.State = EntityState.Modified;
            }
            else
            {
                entry.State = EntityState.Added;
            }

            if (saveImmediately)
            {
                Context.SaveChanges();
            }
        }

        public virtual void Update(TEntity item, long? id, bool saveImmediately = true)
        {
            var t = Context.Set<TEntity>().Local.FirstOrDefault(x => x.Id == id);
            if (t == null)
            {
                t = Context.Set<TEntity>().Find(id);
            }

            Context.Entry(t).CurrentValues.SetValues(item);

            if (saveImmediately)
            {
                Context.SaveChanges();
            }
        }


        public void Delete(TEntity item, bool saveImmediately = true)
        {
            try
            {
                DbSet<TEntity> set = Context.Set<TEntity>();

                DbEntityEntry<TEntity> entry = Context.Entry(item);

                if (entry != null)
                {
                    entry.State = EntityState.Deleted;
                }
                else
                {
                    set.Attach(item);

                    Context.Entry(item).State = EntityState.Deleted;
                }

                if (saveImmediately)
                {
                    Context.SaveChanges();
                }
            }
            finally
            {
            }
        }

        public TEntity Attach(TEntity item)
        {
            DbSet<TEntity> set = Context.Set<TEntity>();
            return set.Attach(item);
        }

        public void Save()
        {
            Context.SaveChanges();

            ((IObjectContextAdapter)Context).ObjectContext.AcceptAllChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~BaseDbDomain()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}
