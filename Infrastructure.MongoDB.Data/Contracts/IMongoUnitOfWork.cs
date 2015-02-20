using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MongoDB.Data.Contracts
{
    interface IMongoUnitOfWork
    {
        MongoDatabase Context { get; }
        void RequestDone();
        void RequestStart();
    }
}
