using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet] // listelemek için
        public IActionResult GuestList()
        {
            var values = _guestService.TGetList();
            return Ok(values); // Burada genellikle bir liste döndürülür, örneğin: return Ok(StaffList); return view gibi
        }

        [HttpPost] // eklemek için
        public IActionResult GuestAdd(Guest guest)
        {
            // Burada genellikle bir model alırsınız ve onu eklemek için kullanırsınız.
            // Örneğin:
            _guestService.TInsert(guest);

            return Ok();
        }


        [HttpDelete("{id}")] // silmek için
        public IActionResult GuestDelete(int id)
        {
            // Silme işlemi için genellikle bir id alırsınız.

            var result = _guestService.TGetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _guestService.TDelete(result);
            return Ok();
        }

        [HttpPut] // güncellemek için
        public IActionResult GuestUpdate(Guest guest)
        {
            // Güncelleme işlemi için genellikle bir model alırsınız.
            _guestService.TUpdate(guest);

            return Ok();
        }


        [HttpGet("{id}")] // İdye göre getirmek için
        public IActionResult GetGuest(int id)
        {
            // İdye göre bir staff bilgisi almak için genellikle bir id alırsınız.
            var result = _guestService.TGetById(id);
            return Ok(result);
        }
    }
}
