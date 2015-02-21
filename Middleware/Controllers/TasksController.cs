using System.Net;
using System.Net.Http;
using System.Web.Http;
using Middleware.Contracts;
using Module.TaskBoard.Contracts;
using Task = Domain.Models.Task;

namespace Middleware.Controllers
{
    public class TasksController : ApiController, ITasksController
    {
        public ITaskTaskBoard TaskModule;

        public TasksController(ITaskTaskBoard taskModule)
        {
            TaskModule = taskModule;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var task = TaskModule.GetLastTasks();

            return Request.CreateResponse(HttpStatusCode.OK, task);
        }

        [HttpGet]
        public HttpResponseMessage Get(long? id, int? month)
        {
            if (id != 0)
            {
                var task = TaskModule.SelectById(id.Value);

                return Request.CreateResponse(HttpStatusCode.OK, task);
            }

            var tasks = TaskModule.GetTasksByMonth();

            return Request.CreateResponse(HttpStatusCode.OK, tasks);

        }

        [HttpDelete]
        public HttpResponseMessage Delete(long id)
        {
            var task = new Task() { Id = id };

            TaskModule.Delete(task);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(Task task)
        {
            TaskModule.Insert(task);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage Put(Task task)
        {
            TaskModule.Update(task);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage ContextualizePage()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
