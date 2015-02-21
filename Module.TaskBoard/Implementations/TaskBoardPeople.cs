using Domain.Models;
using Domain.Services.Contracts;
using System;
using Module.TaskBoard.Contracts;

namespace Module.TaskBoard.Implementations
{
    public class TaskBoardPeople : BaseTaskBoard<People>, IPeopleTaskBoard
    {  
        public IPeopleService Service;

        public TaskBoardPeople(IPeopleService service) : base(service)
        {
            Service = service;
        }
    }
}
