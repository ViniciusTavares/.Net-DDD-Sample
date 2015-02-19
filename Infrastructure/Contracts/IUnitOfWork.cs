using Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        void StartTransaction();
        void Commit();
        void Dispose();
        ApplicationDbContext Context { get; }  
    }
}
