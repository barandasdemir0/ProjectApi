using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult CreateToken()
        {
                return Ok(new CreateToken().TokenCreate()); // boş 200 döner
        }
        [HttpGet("[action]")]
        public IActionResult CreateAdminToken()
        {
                return Ok(new CreateToken().AdminToken()); // boş 200 döner
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult NormalUser()
        {
                return Ok("hoşgeldin"); // boş 200 döner
        }

        [Authorize(Roles = "Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult AdminVisitor()
        {
            return Ok("Token Başarılı şekilde dönüş yapar"); // boş 200 döner
        }


    }
}
