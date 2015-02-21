using System;
using Domain.Models;
using Domain.Services.Contracts;
using Module.TaskBoard.Contracts;

namespace Module.TaskBoard.Implementations
{

    public class TaskBoardTask : ITaskTaskBoard
    {
        public ITaskService Service;

        public TaskBoardTask(ITaskService service)
        {
            Service = service;
        }

        public Task SelectById(long id)
        {
            return Service.Single(id);
        }

        public void Delete(Task task)
        {
            Service.Delete(task);
        }

        public long Insert(Task task)
        {
            task.InsertDate = DateTime.Now;

            return Service.Insert(task);
        }

        public int Update(Task task)
        {
            return Service.Update(task);
        }
    }
}
