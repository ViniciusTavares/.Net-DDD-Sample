using Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Data.Contracts
{
    public interface IHttpManager
    {
        void CloseConnection();
        ApplicationDbContext Context();
    }
}
