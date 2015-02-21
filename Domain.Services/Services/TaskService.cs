
using Domain.Models;
using Domain.Services.Contracts;
using Infrastructure.EF.Data.Contracts;

namespace Domain.Services.Services
{
    public class TaskService : BaseDomainService<Task>, ITaskService
    {
        public TaskService(IUnitOfWork uow) : base(uow) { }
    }
}
