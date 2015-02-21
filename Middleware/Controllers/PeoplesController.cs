using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;
using Domain.Models;
using Middleware.Contracts;
using Module.TaskBoard.Contracts;

namespace Middleware.Controllers
{
    public class PeoplesController : ApiController, IPeopleController
    {
        public IPeopleTaskBoard PeopleModule;

        public PeoplesController(IPeopleTaskBoard peopleModule)
        {
            PeopleModule = peopleModule;
        }

        [HttpGet]
        public HttpResponseMessage Get(long id)
        {
            var people = PeopleModule.SelectById(id);

            return Request.CreateResponse(HttpStatusCode.OK, people);
        }

        [HttpPost]
        public HttpResponseMessage Post(People people)
        {
            PeopleModule.Insert(people);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage Put(People people)
        {
            PeopleModule.Update(people);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}