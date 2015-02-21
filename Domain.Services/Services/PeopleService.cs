
using Domain.Models;
using Domain.Services.Contracts;
using Infrastructure.Config;
using Infrastructure.EF.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Services
{
    public class PeopleService : BaseDomainService<People>, IPeopleService
    {
        public PeopleService(IUnitOfWork uow) : base(uow) { }
    }
}
