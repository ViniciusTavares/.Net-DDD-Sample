using Domain.Models;
using Infrastructure.EF.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class ApplicationDbContext : System.Data.Entity.DbContext
    {
        static ApplicationDbContext()
        {
            Database.SetInitializer(new ContextInitialize());
        }
        public ApplicationDbContext()
            : base("ConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<People> Peoples { get; set; }
        public DbSet<Domain.Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Types().Configure(entity => entity.ToTable("TB_" + entity.ClrType.Name));


            modelBuilder.Configurations.Add(new PeopleMapping());
            modelBuilder.Configurations.Add(new TaskMapping());
        }

    }
}
