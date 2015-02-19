using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum PeopleType
    {
        [Description("User")]
        User = 1,
        [Description("Admin")]
        Administrator = 2
    }
}
