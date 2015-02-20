using Domain.Models;
using Domain.Mongo.Services.Contracts;
using Domain.Services.Contracts;
using Module1.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1.Contracts
{
    public class PeopleContract : IPeopleContract
    {  
        public IPeopleService EFService;
        public IMongoPeopleService MongoService; 

        public PeopleContract(IPeopleService efService, IMongoPeopleService mongoService)
        {
            this.EFService = efService;
            this.MongoService = mongoService; 
        }

        public People SelectById(long id)
        {
            return MongoService.Single(id); 
            //return EFService.Single(id); 
        }

        public void Delete(People people)
        {
            EFService.Delete(people); 
        }

        public long Insert(Domain.Models.People people)
        {
            people.InsertDate = DateTime.Now;

            return EFService.Insert(people);
        }

        public int Update(Domain.Models.People people)
        {
            return EFService.Update(people);
        }
    }
}
