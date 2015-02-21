using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum TaskComplexity
    {
        [Description("Easy")]
        Easy = 1,
        [Description("Normal")]
        Normal = 2,
        [Description("Hardcore")]
        Hard = 3
    }
}
