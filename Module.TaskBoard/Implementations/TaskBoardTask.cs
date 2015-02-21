using System;
using System.Collections.Generic;
using Domain.Models;
using Domain.Services.Contracts;
using Module.TaskBoard.Contracts;

namespace Module.TaskBoard.Implementations
{

    public class TaskBoardTask : BaseTaskBoard<Task>, ITaskTaskBoard
    {
        public ITaskService Service;

        public TaskBoardTask(ITaskService service) : base(service)
        {
            Service = service;
        }

        public List<Task> GetLastTasks()
        {
            DateTime aWeekAgo = DateTime.Now.AddDays(-7);

            return Service.GetLastTasks(aWeekAgo);
        }
        public List<Task> GetTasksByMonth()
        {
            return Service.GetTasksByMonth();
        } 
    }
}
