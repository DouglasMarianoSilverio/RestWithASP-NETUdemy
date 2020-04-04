using RestWithASPNETUdemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private  volatile int count;

        public Person Create(Person person)
        {
            return CreateFakePerson();
        }

        public void Delete(long id)
        {
            
        }

        public IList<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i =0; i< 8; i++)
            {
                persons.Add(CreateFakePerson()); 
            }
            return persons;
        }

        public Person FindbyId(long id)
        {
            return CreateFakePerson();
        }

        public Person Update(Person person)
        {
            return person;
        }
        private Person CreateFakePerson()
        {
            return new Person()
            {
                Id = ImplementAndGet(),
                FirstName = "Person Name",
                LastName = $"Person LastName {count.ToString()}",
                Address = "minha casa",
                Gender = Gender.Masculino
            };
        }

        private long ImplementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
