using System;
using Domain.Enums;
using Domain;

namespace Domain.Models
{
    public class People : BaseEntity
    {
        public string Name { get; set; }
        public Int16 Age { get; set; }
        public PeopleType Type { get; set; }
    }
}
