using Infrastructure.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Contracts
{
    public interface IBaseDbDomain<T>   where T : BaseEntity, new()
    {
        int Delete(T entity);
        void Dispose();
        bool Exists(object primaryKey);
        System.Collections.Generic.IEnumerable<T> GetAll();
        long Insert(T entity);
        T Single(object primaryKey);
        T SingleOrDefault(object primaryKey);
        IUnitOfWork UnitOfWork { get; }
        int Update(T entity);
    }
}
