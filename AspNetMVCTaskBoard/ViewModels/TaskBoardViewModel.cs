using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMVCTaskBoard.ViewModels
{
    public class TaskBoardViewModel
    {
        public TaskBoardViewModel()
        {
            Tasks = new List<Task>();
        }

        public ICollection<Task> Tasks { get; set; }
       
    }
}