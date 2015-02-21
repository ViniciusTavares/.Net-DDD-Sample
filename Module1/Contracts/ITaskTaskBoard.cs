using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.TaskBoard.Contracts
{
    public interface ITaskTaskBoard
    {
        void Delete(Domain.Models.Task people);
        long Insert(Domain.Models.Task people);
        Domain.Models.Task SelectById(long id);
        int Update(Domain.Models.Task people);
    }
    
}
