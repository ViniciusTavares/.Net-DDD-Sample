using Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Interfaces
{
    public interface IPeopleController
    {
        HttpResponseMessage People(long id);
        HttpResponseMessage People(People people); 
    }
}
