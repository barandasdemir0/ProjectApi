using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet] // listelemek için
        public IActionResult ServiceList()
        {
            var values = _serviceService.TGetList();
            return Ok(values); // Burada genellikle bir liste döndürülür, örneğin: return Ok(ServiceList); return view gibi
        }

        [HttpPost] // eklemek için
        public IActionResult ServiceAdd(Service service)
        {
            // Burada genellikle bir model alırsınız ve onu eklemek için kullanırsınız.
            // Örneğin:
            _serviceService.TInsert(service);

            return Ok();
        }


        [HttpDelete] // silmek için
        public IActionResult ServiceDelete(int id)
        {
            // Silme işlemi için genellikle bir id alırsınız.

            var result = _serviceService.TGetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _serviceService.TDelete(result);
            return Ok();
        }

        [HttpPut] // güncellemek için
        public IActionResult ServiceUpdate(Service service)
        {
            // Güncelleme işlemi için genellikle bir model alırsınız.
            _serviceService.TUpdate(service);

            return Ok();
        }


        [HttpGet("{id}")] // İdye göre getirmek için
        public IActionResult GetService(int id)
        {
            // İdye göre bir Service bilgisi almak için genellikle bir id alırsınız.
            var result = _serviceService.TGetById(id);
            return Ok(result);
        }
    }
}
