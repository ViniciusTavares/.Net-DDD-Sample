using Domain.Services.Services;
using Domain.Services;
using Domain.Services.Contracts;
using Module.TaskBoard.Contracts;
using Module.TaskBoard.Implementations;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EF.Data.Contracts;
using Infrastructure.Config;
using Infrastructure.EF_Config;

namespace Infrastructure.CrossCutting
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(t =>
            {
                // Domain.Services
                t.For(typeof(IPeopleService)).Use(typeof(PeopleService));
                t.For(typeof(ITaskService)).Use(typeof(TaskService));

                // Infrastructure
                t.For(typeof(IHttpManager)).Use(typeof(HttpManager));
                t.For(typeof(IUnitOfWork)).Use(typeof(UnitOfWork));

                // Modules
                t.For(typeof(IPeopleTaskBoard)).Use(typeof(TaskBoardPeople));
                t.For(typeof(ITaskTaskBoard)).Use(typeof(TaskBoardTask)); 
            });

            return ObjectFactory.Container;
        }
    }
}
