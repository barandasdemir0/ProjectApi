using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService  _workLocationService;

        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }

        [HttpGet] // listelemek için
        public IActionResult WorkLocationList()
        {
            var values = _workLocationService.TGetList();
            return Ok(values); // Burada genellikle bir liste döndürülür, örneğin: return Ok(WorkLocationList); return view gibi
        }

        [HttpPost] // eklemek için
        public IActionResult WorkLocationAdd(WorkLocation workLocation)
        {
            // Burada genellikle bir model alırsınız ve onu eklemek için kullanırsınız.
            // Örneğin:
            _workLocationService.TInsert(workLocation);

            return Ok();
        }


        [HttpDelete("{id}")] // silmek için
        public IActionResult WorkLocationDelete(int id)
        {
            // Silme işlemi için genellikle bir id alırsınız.

            var result = _workLocationService.TGetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _workLocationService.TDelete(result);
            return Ok();
        }

        [HttpPut] // güncellemek için
        public IActionResult WorkLocationUpdate(WorkLocation workLocation)
        {
            // Güncelleme işlemi için genellikle bir model alırsınız.
            _workLocationService.TUpdate(workLocation);

            return Ok();
        }


        [HttpGet("{id}")] // İdye göre getirmek için
        public IActionResult GetWorkLocation(int id)
        {
            // İdye göre bir WorkLocation bilgisi almak için genellikle bir id alırsınız.
            var result = _workLocationService.TGetById(id);
            return Ok(result);
        }
    }
}
