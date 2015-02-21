
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Services.Contracts;
using Infrastructure.EF.Data.Contracts;

namespace Domain.Services.Services
{
    public class TaskService : BaseDomainService<Task>, ITaskService
    {
        public TaskService(IUnitOfWork uow) : base(uow) { }

        public List<Task> GetLastTasks(DateTime aWeekAgo)
        {
            var tasks = Uow.Context.Tasks.Where(t => t.Day >= aWeekAgo);

            return tasks.ToList();
        }

        public List<Task> GetTasksByMonth()
        {   
            var tasks = Uow.Context.Tasks.Where(t => t.Day >= DateTime.Now.AddMonths(-1));

            return tasks.ToList();
        } 
    }
}
