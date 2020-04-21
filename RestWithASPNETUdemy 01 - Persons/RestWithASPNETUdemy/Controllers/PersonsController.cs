using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personService)
        {
            _personBusiness = personService;
        }

        // GET: api/Persons
        [HttpGet]
        [ProducesResponseType(typeof(List<PersonVO>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonVO), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindbyId(id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        // POST: api/Persons
        [HttpPost]
        [ProducesResponseType(typeof(PersonVO), 201)]        
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT: api/Persons/5
        [HttpPut]
        [ProducesResponseType(typeof(PersonVO), 200)]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();

            var updatePerson = _personBusiness.Update(person);

            if (updatePerson == null)
                return NoContent();

            return new ObjectResult(updatePerson);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]        
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();

        }
    }
}
