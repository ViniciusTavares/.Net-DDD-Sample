using System;
using System.Collections.Generic;
using Task = Domain.Models.Task;

namespace Domain.Services.Contracts
{
    public interface ITaskService  : IBaseDomainService<Task>
    {
        List<Task> GetLastTasks(DateTime aWeekAgo);
        List<Task> GetTasksByMonth();
    }
}
