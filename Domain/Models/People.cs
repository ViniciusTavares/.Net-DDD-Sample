using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class People : BaseEntity
    {
        public People()
        {
            Tasks = new List<Task>(); 
        }

        public string Name { get; set; }
        public Int16 Age { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
