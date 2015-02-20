using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Domain.Services.Contracts;
using Microsoft.Practices.ServiceLocation;
using Infrastructure.EF.Data.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class BaseDomainService<T> : IDisposable, IBaseDomainService<T> where T : BaseEntity, new()
    {
        private readonly IUnitOfWork Uow;
        internal DbSet<T> dbSet;

        public BaseDomainService(IUnitOfWork uow)
        {
            this.Uow = uow;
            this.dbSet = Uow.Context.Set<T>();
        }

        public T Single(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }

        public T SingleOrDefault(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }

        public bool Exists(object primaryKey)
        {
            return dbSet.Find(primaryKey) == null ? false : true;
        }

        public virtual long Insert(T entity)
        {
            dynamic obj = dbSet.Add(entity);
            this.Uow.Context.SaveChanges();
            return obj.Id;
        }

        public virtual int Update(T entity)
        {
            dbSet.Attach(entity);
            Uow.Context.Entry(entity).State = EntityState.Modified;
            return this.Uow.Context.SaveChanges();
        }
        public int Delete(T entity)
        {
            if (Uow.Context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dynamic obj = dbSet.Remove(entity);
            this.Uow.Context.SaveChanges();
            return obj.Id;
        }

        public IUnitOfWork UnitOfWork { get { return Uow; } }

        internal DbContext Database { get { return Uow.Context; } }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable().ToList();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~BaseDomainService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Uow.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
