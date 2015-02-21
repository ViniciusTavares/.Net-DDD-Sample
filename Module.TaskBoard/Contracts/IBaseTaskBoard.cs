using Domain.Models;

namespace Module.TaskBoard.Contracts
{
    public interface IBaseTaskBoard<T> where T : BaseEntity, new()
    {
        T SelectById(long id);
        void Delete(T entity);
        long Insert(T entity);
        int Update(T entity);
    }
}