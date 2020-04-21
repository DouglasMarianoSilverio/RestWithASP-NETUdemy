using RestWithASPNETUdemy.Models;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindbyId(long id);
        IList<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
        bool Exists(long? id);

    }
}
