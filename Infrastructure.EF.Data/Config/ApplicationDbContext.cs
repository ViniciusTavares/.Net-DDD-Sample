using Domain.Models;
using Infrastructure.EF.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class ApplicationDbContext : System.Data.Entity.DbContext
    {
        public ApplicationDbContext()
            : base("ConnectionString")
        {
            System.Data.Entity.Database.SetInitializer(new ContextInitialize());
        }

        public DbSet<People> Peoples { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PeopleConfig());
        }

    }
}
