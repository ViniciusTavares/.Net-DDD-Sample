using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Domain.Models;

namespace Middleware.Contracts
{
    public interface ITasksController
    {
        HttpResponseMessage Get(long? id, int? month);
        HttpResponseMessage Delete(long id);
        HttpResponseMessage Post(Task task);
        HttpResponseMessage Put(Task task);
        HttpResponseMessage ContextualizePage();

    }
}
