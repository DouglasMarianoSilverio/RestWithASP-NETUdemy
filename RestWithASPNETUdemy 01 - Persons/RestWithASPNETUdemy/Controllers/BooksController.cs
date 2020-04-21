using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBookBusiness _bookBusiness;

        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        // GET: api/Books
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var entity = _bookBusiness.FindbyId(id);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }

        // POST: api/Books
        [HttpPost("")]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null)
                return BadRequest();
            return new ObjectResult(_bookBusiness.Create(book));
        }

        // PUT: api/Books/5
        [HttpPut]
        public IActionResult Put( [FromBody] BookVO book)
        {
            if (book == null)
                return BadRequest();

            var updateBook = _bookBusiness.Update(book);

            if (updateBook == null)
                return NoContent();

            return new ObjectResult(updateBook);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
