using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Contracts
{
    public interface IPeopleContract
    {
        HttpResponseMessage People(long id);
        HttpResponseMessage People(People people); 
    }
}
