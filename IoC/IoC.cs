using Domain.Services;
using Domain.Services.Contracts;
using Infrastructure.Config;
using Infrastructure.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
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
            });

            return ObjectFactory.Container;
        }
    }
}
