using Domain.Models;
using Domain.Mongo.Services.Contracts;
using Infrastructure.MongoDB.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mongo.Services.Services
{
    public class MongoPeopleService : BaseDomainService<People>, IMongoPeopleService
    {
        public MongoPeopleService(IMongoUnitOfWork uow) : base(uow) { }
    }
}
