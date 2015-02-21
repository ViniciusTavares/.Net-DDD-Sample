using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Models
{
    public class Task : BaseEntity
    {
        public Task()
        {
            Peoples = new List<People>();
        }

        public string Description { get; set; }
        public DateTime Day { get; set; }
        public ICollection<People> Peoples { get; set; }
        public TaskComplexity Complexity { get; set; }

        #region Methods
        public int CountUsers()
        {
            return Peoples.Count();
        }
        #endregion


        public object Name { get; set; }
    }
}
