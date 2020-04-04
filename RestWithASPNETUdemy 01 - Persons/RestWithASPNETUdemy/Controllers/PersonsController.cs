using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/Persons
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindbyId(id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        // POST: api/Persons
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {            
            if (person == null)
                return BadRequest();
            return new ObjectResult(_personService.Create(person));
        }

        // PUT: api/Persons/5
        [HttpPut]
        public IActionResult Put( [FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            return new ObjectResult(_personService.Update(person));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return NoContent();
        }
    }
}
