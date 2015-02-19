using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Contracts
{
    public interface IBaseDbDomain<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> where = null, IOrderByClause<TEntity>[] orderBy = null, int skip = 0, int top = 0, string[] include = null, bool readOnly = false);
        TEntity SelectById(long id);
        TEntity Insert(TEntity item, bool saveImmediately = true);
        void Update(TEntity item, long? id, bool saveImmediately = true);
        void Delete(TEntity item, bool saveImmediately = true);
        TEntity Attach(TEntity item);
        void AddOrUpdate(TEntity item, bool saveImmediately = true);
        void Save();
    }
}
