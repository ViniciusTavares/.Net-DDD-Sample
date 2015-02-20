using Infrastructure.MongoDB.Data.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MongoDB.Data.Config
{
    public class MongoUnitOfWork : IMongoUnitOfWork
    {
        private readonly MongoDatabase MongoDatabase;
        MongoServer Server;

        public MongoDatabase Context
        {
            get
            {
                return this.MongoDatabase;
            }
        }

        public MongoUnitOfWork()
        {
            MongoUrl url = new MongoUrl("mongodb://localhost/vinicius_db");
            MongoClient client = new MongoClient(url);
            Server = client.GetServer();
            MongoDatabase = Server.GetDatabase(url.DatabaseName);
        }

        public void RequestStart()
        {
            Server.RequestStart(this.MongoDatabase);
        }

        public void RequestDone()
        {
            Server.RequestDone();
        }
    }
}
