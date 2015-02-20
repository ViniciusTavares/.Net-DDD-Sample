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
using Infrastructure.MongoDB.Data.Contracts;
using Infrastructure.MongoDB.Data.Config;
using Domain.Mongo.Services.Contracts;
using Domain.Mongo.Services.Services;

namespace Infrastructure.CrossCutting
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(t =>
            {
                // Infrastructure
                t.For(typeof(IUnitOfWork)).Use(typeof(EFUnitOfWork));
                t.For(typeof(IMongoUnitOfWork)).Use(typeof(MongoUnitOfWork));

                // Domain.Services
                t.For(typeof(IPeopleService)).Use(typeof(PeopleService));
                t.For(typeof(IMongoPeopleService)).Use(typeof(MongoPeopleService)); 

                // Modules
                t.For(typeof(IPeopleContract)).Use(typeof(PeopleContract)); 
            });

            return ObjectFactory.Container;
        }
    }
}
