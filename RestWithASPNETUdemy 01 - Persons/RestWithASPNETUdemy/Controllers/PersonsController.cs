using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {            
            if (person == null)
                return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT: api/Persons/5
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put( [FromBody] PersonVO person)
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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
            
        }
    }
}
