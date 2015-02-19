
using Domain.Models;
using Domain.Services.Contracts;
using Module1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1.Contracts
{
    public class PeopleContract : IPeopleContract
    {  
        public IPeopleService Service;

        public PeopleContract(IPeopleService service)
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
