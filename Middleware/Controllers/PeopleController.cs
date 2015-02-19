using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;
using Domain.Models;
using Domain.Services.Contracts;
using Middleware.Interfaces;
using Module1.Interfaces;

namespace Middleware.Controllers
{
    public class PeopleController : ApiController, IPeopleController
    {
        public IPeopleContract Contract;

        public PeopleController(IPeopleContract contract)
        {
            Contract = contract;
        }

        [HttpGet]
        [HttpDelete]
        public HttpResponseMessage People(long id)
        {
            if (Request.Method.Method == "GET")
            {
                var people = Contract.SelectById(id); 

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                People people = new People() { Id = id };

                Contract.Delete(people); 

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpPost]
        [HttpPut]
        public HttpResponseMessage People(People people)
        {
            people.UpdateDate = DateTime.Now;
            long id; 

            if (Request.Method.Method == "POST")
            {
              id =  Contract.Insert(people);
            }
            else
            {
              id =  Contract.Update(people); 
            }

            return Request.CreateResponse(HttpStatusCode.OK, id);
        }


    }
}