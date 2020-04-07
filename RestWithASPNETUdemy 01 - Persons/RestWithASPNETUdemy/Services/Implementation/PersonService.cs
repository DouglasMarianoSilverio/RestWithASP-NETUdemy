using RestWithASPNETUdemy.Context;
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
        
        private MySQLContext _context;

        public PersonService(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindbyId(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id == id);
        }

        public Person Update(Person person)
        {
            // Verificamos se a pessoa existe na base
            // Se não existir retornamos uma instancia vazia de pessoa
            if (!Exists(person.Id)) return new Person();

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = _context.Persons.SingleOrDefault(b => b.Id == person.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        private bool Exists(long? id)
        {
            return _context.Persons.Any(p => p.Id == id);
        }
    }
}
