using System;
using Domain.Models;
using Domain.Services;
using Domain.Services.Contracts;
using Module.TaskBoard.Contracts;

namespace Module.TaskBoard.Implementations
{
    public class BaseTaskBoard<T> : IBaseTaskBoard<T> where T : BaseEntity, new()
    {
        private readonly IBaseDomainService<T> _service; 

        public BaseTaskBoard(IBaseDomainService<T> service)
        {
            _service = service; 
        }  

        public T SelectById(long id)
        {
            return _service.Single(id); 
        }

        public void Delete(T entity)
        {
            _service.Delete(entity); 
        }

        public long Insert(T entity)
        {
            return _service.Insert(entity);
        }

        public int Update(T entity)
        {
            return _service.Update(entity);
        }
    }
}
