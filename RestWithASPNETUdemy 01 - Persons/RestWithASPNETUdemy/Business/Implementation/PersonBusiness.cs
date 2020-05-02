using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementation
{
    public class PersonBusiness : IPersonBusiness
    {
        
        private IPersonRepository _personRepository;
        public readonly PersonConverter _converter;

        public PersonBusiness(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _personRepository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }

        public IList<PersonVO> FindAll()
        {
            return  _converter.ParseList(_personRepository.FindAll()) ;
        }

        public IList<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.ParseList(_personRepository.FindByName(firstName, lastName));
        }

        public PersonVO FindbyId(long id)
        {
            return _converter.Parse(_personRepository.FindbyId(id));
        }

        public PersonVO Update(PersonVO person)
        {
            //eeek
            //return _converter.Parse(_personRepository.Update(_converter.Parse(person)));
            var personEntity = _converter.Parse(person);
            personEntity = _personRepository.Update(personEntity);
            return _converter.Parse(personEntity);
        }      
    }
}
