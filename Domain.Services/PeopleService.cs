
using Domain.Models;
using Domain.Services.Contracts;
using Infrastructure.Config;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class PeopleService : BaseDbDomain<People>, IPeopleService
    {
        public PeopleService(IHttpManager manager) : base(manager.Context()){}
    }
}
