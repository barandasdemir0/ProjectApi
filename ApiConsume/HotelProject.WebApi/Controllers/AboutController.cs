using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet] // listelemek için
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetList();
            return Ok(values); // Burada genellikle bir liste döndürülür, örneğin: return Ok(StaffList); return view gibi
        }

        [HttpPost] // eklemek için
        public IActionResult AboutAdd(About about)
        {
            // Burada genellikle bir model alırsınız ve onu eklemek için kullanırsınız.
            // Örneğin:
            _aboutService.TInsert(about);

            return Ok();
        }


        [HttpDelete("{id}")] // silmek için
        public IActionResult AboutDelete(int id)
        {
            // Silme işlemi için genellikle bir id alırsınız.

            var result = _aboutService.TGetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _aboutService.TDelete(result);
            return Ok();
        }

        [HttpPut] // güncellemek için
        public IActionResult AboutUpdate(About about)
        {
            // Güncelleme işlemi için genellikle bir model alırsınız.
            _aboutService.TUpdate(about);

            return Ok();
        }


        [HttpGet("{id}")] // İdye göre getirmek için
        public IActionResult GetAbout(int id)
        {
            // İdye göre bir staff bilgisi almak için genellikle bir id alırsınız.
            var result = _aboutService.TGetById(id);
            return Ok(result);
        }
    }
}
