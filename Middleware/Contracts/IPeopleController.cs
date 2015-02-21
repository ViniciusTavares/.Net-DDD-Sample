using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Contracts
{
    public interface IPeopleController
    {
        HttpResponseMessage Get(long id);
        HttpResponseMessage Post(People people);
        HttpResponseMessage Put(People people); 
    }
}
