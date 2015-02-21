using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Task = Domain.Models.Task;

namespace Infrastructure.EF.Data.Mapping
{
    public class TaskMapping : EntityTypeConfiguration<Task>
    {
       public TaskMapping() {

         HasMany(c => c.Peoples).
         WithMany(p => p.Tasks).
         Map(
          m =>
          {
              m.MapLeftKey("PeopleId");
              m.MapRightKey("TaskId");
              m.ToTable("TB_PeopleTasks");
          });


        }
    }
}
