
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
    public class PeopleService : BaseDomainService<People>, IPeopleService
    {
        public PeopleService(IUnitOfWork uow) : base(uow) { }
    }
}
