using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        //[HttpGet] // listelemek için
        //public IActionResult UserListWithWorkLocation()
        //{
        //    var values = _appUserService.TUserListWithLocation();
        //    return Ok(values); // Burada genellikle bir liste döndürülür, örneğin: return Ok(AppUserList); return view gibi
        //}

        [HttpGet] // listelemek için
        public IActionResult AppUserList()
        {
            var values = _appUserService.TGetList();
            return Ok(values); // Burada genellikle bir liste döndürülür, örneğin: return Ok(AppUserList); return view gibi
        }

        [HttpPost] // eklemek için
        public IActionResult AppUserAdd(AppUser appUser)
        {
            // Burada genellikle bir model alırsınız ve onu eklemek için kullanırsınız.
            // Örneğin:
            _appUserService.TInsert(appUser);

            return Ok();
        }


        [HttpDelete("{id}")] // silmek için
        public IActionResult AppUserDelete(int id)
        {
            // Silme işlemi için genellikle bir id alırsınız.

            var result = _appUserService.TGetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _appUserService.TDelete(result);
            return Ok();
        }

        [HttpPut] // güncellemek için
        public IActionResult AppUserUpdate(AppUser appUser)
        {
            // Güncelleme işlemi için genellikle bir model alırsınız.
            _appUserService.TUpdate(appUser);

            return Ok();
        }


        [HttpGet("{id}")] // İdye göre getirmek için
        public IActionResult GetAppUser(int id)
        {
            // İdye göre bir AppUser bilgisi almak için genellikle bir id alırsınız.
            var result = _appUserService.TGetById(id);
            return Ok(result);
        }
    }
}
