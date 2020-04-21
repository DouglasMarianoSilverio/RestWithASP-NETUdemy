using RestWithASPNETUdemy.Data.Converter;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public PersonVO Parse(Person origin)
        {
            if (origin == null) 
                return new PersonVO();
            return new PersonVO()
            {
                Id = origin.Id,
                Address = origin.Address,
                FirstName = origin.FirstName,
                Gender = origin.Gender,
                LastName = origin.LastName
            };
        }

        public Person Parse(PersonVO origin)
        {
            //why don't use autoMapper?
            if (origin == null) 
                return new Person();
            return new Person()
            {
                Id = origin.Id,
                Address = origin.Address,
                FirstName = origin.FirstName,
                Gender = origin.Gender,
                LastName = origin.LastName
            };
        }

        public IList<PersonVO> ParseList(IList<Person> origin)
        {
            if (origin == null) 
                return new List<PersonVO>();

            return origin.Select(item => Parse(item)).ToList();
        }

        public IList<Person> ParseList(IList<PersonVO> origin)
        {
            if (origin == null) 
                return new List<Person>();

            return origin.Select(item => Parse(item)).ToList(); 
        }
    }
}
