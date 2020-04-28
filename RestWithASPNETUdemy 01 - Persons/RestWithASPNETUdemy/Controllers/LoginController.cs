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
    public class LoginController : ControllerBase
    {
        private readonly ILoginBusiness _business;

        public LoginController(ILoginBusiness business)
        {
            _business = business;
        }

       

        // POST: api/Persons
        [AllowAnonymous]
        [HttpPost]
        
        public object Post([FromBody] User user)
        {
            if (user == null)
                return BadRequest();
            return  _business.FindByLogin(user);
        }

         
    }
}
