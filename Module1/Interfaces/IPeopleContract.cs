using System;
namespace Module1.Interfaces
{
    public interface IPeopleContract
    {
        void Delete(Domain.Models.People people);
        long Insert(Domain.Models.People people);
        Domain.Models.People SelectById(long id);
        int Update(Domain.Models.People people);
    }
}
