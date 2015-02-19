using Infrastructure.Config;
using Infrastructure.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF_Config
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext Context;

        public void Begin()
        {
            var manager = ServiceLocator.Current.GetInstance<IHttpManager>();

            Context = manager.Context();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
