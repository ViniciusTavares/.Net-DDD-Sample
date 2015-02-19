using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;
using Domain.Models;
using Domain.Services.Contracts;
using Middleware.Contracts;

namespace Middleware.Controllers
{
    public class PeopleController : ApiController, IPeopleContract
    {
        public IPeopleService Service;

        public PeopleController(IPeopleService service)
        {
            Service = service;
        }

        public class PeopleDto
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        [HttpGet]
        [HttpDelete]
        public HttpResponseMessage People(long id)
        {
            if (Request.Method.Method == "GET")
            {
                var people = Service.SelectById(id);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                People p = new People() { Id = id };

                Service.Delete(p);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpPost]
        [HttpPut]
        public HttpResponseMessage People(People people)
        {
            people.UpdateDate = DateTime.Now; 
            
            if (Request.Method.Method == "POST")
            {
                people.InsertDate = DateTime.Now; 

                Service.Insert(people);
            }
            else
            {
                Service.Update(people, people.Id);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}