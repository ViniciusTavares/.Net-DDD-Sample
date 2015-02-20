namespace Infrastructure.Migrations
{
    using Domain.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.Config.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Infrastructure.Config.ApplicationDbContext context)
        {
            context.Peoples.Add(new People
            {
                Name = "Vinicius Rafael Tavares",
                Age = 21,
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Type = Domain.Enums.PeopleType.NaturalPerson
            });

        }
    }
}
