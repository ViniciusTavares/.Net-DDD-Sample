﻿using Domain.Models;
using Domain.Mongo.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Builders;
using Infrastructure.MongoDB.Data.Contracts;
using MongoDB.Driver;
using Core;
using MongoDB.Bson;

namespace Domain.Mongo.Services.Services
{
    public class BaseDomainService<T> : IDisposable, IBaseDomainService<T> where T : BaseEntity, new()
    {
        private readonly MongoCollection Collection;
        IMongoUnitOfWork Uow; 

        public BaseDomainService(IMongoUnitOfWork uow)
        {
            string collectionName = typeof(T).ToString();
            Uow = uow; 
            this.Collection = Uow.Context.GetCollection("Peoples");
        }

        public T Single(object id)
        {
            return Collection.FindOneAs<T>(Query.EQ("Name", "Vinicius")); 
            //return Collection.FindOneByIdAs<T>(id.ToString());
        }

        public IEnumerable<T> GetAll()
        {
            return Collection.FindAllAs<T>(); 
        }

        public IEnumerable<T> Get(IMongoQuery query)
        {
            return Collection.FindAs<T>(query);
        }

        public bool Exists(object id)
        {
            return Collection.FindOneByIdAs<T>(id.ToString()) != null;
        }

        public virtual void Save(T entity)
        {
            Collection.Save(entity);  
        }

        public virtual void SaveAll(IEnumerable<T> items)
        {
            items.ToList().ForEach(Save);
        }

        public void Delete(object id)
        {
            Collection.Remove(Query.EQ("_id", id.ToString()));
        }

        public void DeleteAll()
        {
            Collection.RemoveAll();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public long Count()
        {
            return Collection.Count();
        }

        ~BaseDomainService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Uow.RequestDone();
                GC.SuppressFinalize(this);
            }
        }
    }
}
