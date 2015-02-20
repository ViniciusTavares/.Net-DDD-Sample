using Domain.Models;
using Infrastructure.EF_Config;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class ContextInitialize : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Peoples.Add(new People
            {
               Name = "Vinicius Rafael Tavares",
               Age = 21,
               InsertDate = DateTime.Now, 
               UpdateDate = DateTime.Now,
               Type = Domain.Enums.PeopleType.LegalPerson
            });

            base.Seed(context);
        }

       
    }
}
