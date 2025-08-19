using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet] // listelemek için
        public IActionResult StaffList()
        {
            var values = _staffService.TGetList();
            return Ok(values); // Burada genellikle bir liste döndürülür, örneğin: return Ok(StaffList); return view gibi
        }

        [HttpPost] // eklemek için
        public IActionResult StaffAdd(Staff staff)
        {
            // Burada genellikle bir model alırsınız ve onu eklemek için kullanırsınız.
            // Örneğin:
            _staffService.TInsert(staff);

            return Ok();
        }


        [HttpDelete("{id}")] // silmek için
        public IActionResult StaffDelete(int id)
        {
            // Silme işlemi için genellikle bir id alırsınız.

            var result = _staffService.TGetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _staffService.TDelete(result);
            return Ok();
        }

        [HttpPut] // güncellemek için
        public IActionResult StaffUpdate(Staff staff)
        {
            // Güncelleme işlemi için genellikle bir model alırsınız.
            _staffService.TUpdate(staff);

            return Ok();
        }


        [HttpGet("{id}")] // İdye göre getirmek için
        public IActionResult GetStaff(int id)
        {
            // İdye göre bir staff bilgisi almak için genellikle bir id alırsınız.
            var result = _staffService.TGetById(id);
            return Ok(result);
        }


        [HttpGet("Last4Staff")] // İdye göre getirmek için
        public IActionResult Last4Staff()
        {
            // İdye göre bir staff bilgisi almak için genellikle bir id alırsınız.
            var result = _staffService.TLast4Staff();
            return Ok(result);
        }
    }
}
