using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

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
        
        public PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : page;

            string query = "select * from Persons p where 1=1 ";
            if (!string.IsNullOrEmpty(name)) query += $" and p.firstName like '%{name}%' ";
             query += $" order by p.Firstname {sortDirection} limit {pageSize} offset {page} ";

            var persons = _converter.ParseList(_personRepository.FindWithPagedSearch(query));

            string countQuery = @"select count(0) from Persons p where 1=1 ";
            if (!string.IsNullOrEmpty(name))
                countQuery += $" and p.firstName like '%{name}%' ";

            var totalResults = _personRepository.GetCount(countQuery);

            return new PagedSearchDTO<PersonVO>() {
                CurrentPage= page +1 ,
                PageSize = pageSize,
                List = persons as List<PersonVO>,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };

        }
    }
}
