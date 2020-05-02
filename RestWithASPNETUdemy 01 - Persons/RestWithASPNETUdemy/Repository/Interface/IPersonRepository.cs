using RestWithASPNETUdemy.Models;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public interface IPersonRepository : IRepository<Person>
    {
        IList<Person> FindByName(string firstName, string lastName);
    }
}
