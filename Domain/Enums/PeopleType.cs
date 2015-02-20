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
        [Description("Legal Person")]
        LegalPerson = 1,
        [Description("Natural Person")]
        NaturalPerson = 2
    }
}
