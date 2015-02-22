using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Status
    {
        [Description("Completed")]
        Completed = 1, 
        [Description("Cancelled")]
        Cancelled= 2, 
        [Description("InProgress")]
        InProgress = 3
    }
}
