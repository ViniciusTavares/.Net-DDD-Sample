using Domain.Models;
using Domain.Services.Contracts;
using System;
using Module.TaskBoard.Contracts;

namespace Module.TaskBoard.Implementations
{
    public class TaskBoardPeople : IPeopleTaskBoard
    {  
        public IPeopleService Service;

        public TaskBoardPeople(IPeopleService service)
        {
            Service = service;
        }

        public People SelectById(long id)
        {
            return Service.Single(id); 
        }

        public void Delete(People people)
        {
            Service.Delete(people); 
        }

        public long Insert(Domain.Models.People people)
        {
            people.InsertDate = DateTime.Now;

            return Service.Insert(people);
        }

        public int Update(Domain.Models.People people)
        {
            return Service.Update(people);
        }
    }
}
