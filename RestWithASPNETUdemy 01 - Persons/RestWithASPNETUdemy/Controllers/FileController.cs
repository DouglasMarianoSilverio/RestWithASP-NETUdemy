using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;
using Tapioca.HATEOAS;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileBusiness _business;

        public FileController(IFileBusiness business)
        {
            _business = business;
        }



        // POST: api/Persons
        [HttpGet("")]
        [ProducesResponseType(typeof(byte[]), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]        
        public FileContentResult Get()
        {
            var buffer = _business.GetPdfFile();
            return new FileContentResult(buffer, "application/PDF");
        }

         
    }
}
