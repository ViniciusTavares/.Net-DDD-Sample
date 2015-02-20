using Infrastructure.Config;
using Infrastructure.EF.Data.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastructure.EF_Config
{
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope Transaction;
        private readonly ApplicationDbContext DbContext;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.DbContext = context;
        }
        public void StartTransaction()
        {
            Transaction = new TransactionScope();
        }

        public void Commit()
        {
            DbContext.SaveChanges();
            Transaction.Complete();
        }

        public ApplicationDbContext Context
        {
            get
            {
                return this.DbContext;
            }
        }

        public void Dispose()
        {
            Transaction.Dispose();
            DbContext.Dispose();
        }

    }
}
