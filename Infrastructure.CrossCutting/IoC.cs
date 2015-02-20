using Module1.Contracts;
using Domain.Services;
using Domain.Services.Contracts;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module1.Interfaces;
using Infrastructure.Interfaces;
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

                // Infrastructure
                t.For(typeof(IHttpManager)).Use(typeof(HttpManager));
                t.For(typeof(IUnitOfWork)).Use(typeof(EFUnitOfWork));

                // Modules
                t.For(typeof(IPeopleContract)).Use(typeof(PeopleContract)); 
            });

            return ObjectFactory.Container;
        }
    }
}
