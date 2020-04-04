using RestWithASPNETUdemy.Models;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindbyId(long id);
        IList<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);

    }
}
