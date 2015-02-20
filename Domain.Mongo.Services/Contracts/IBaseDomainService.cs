using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mongo.Services.Contracts
{
    public interface IBaseDomainService<T> where T : Domain.Models.BaseEntity, new()
    {
        long Count();
        void Delete(object id);
        void DeleteAll();
        void Dispose();
        bool Exists(object id);
        System.Collections.Generic.IEnumerable<T> Get(MongoDB.Driver.IMongoQuery query);
        System.Collections.Generic.IEnumerable<T> GetAll();
        void Save(T entity);
        void SaveAll(System.Collections.Generic.IEnumerable<T> items);
        T Single(object id);
    }
}
