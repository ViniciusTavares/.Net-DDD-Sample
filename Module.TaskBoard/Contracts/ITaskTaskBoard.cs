

using System.Collections.Generic;
using System.Threading.Tasks;
using Task = Domain.Models.Task;

namespace Module.TaskBoard.Contracts
{
    public interface ITaskTaskBoard : IBaseTaskBoard<Task>
    {
        List<Task> GetLastTasks();
        List<Task> GetTasksByMonth(); 
    }
    
}
