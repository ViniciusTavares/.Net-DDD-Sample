using System;
using Domain.Enums;
using Domain;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    public class People : BaseEntity
    {
        public string Name { get; set; }
        public Int16 Age { get; set; }
        [BsonElement("PeopleType")]
        public PeopleType Type { get; set; }
    }
}
