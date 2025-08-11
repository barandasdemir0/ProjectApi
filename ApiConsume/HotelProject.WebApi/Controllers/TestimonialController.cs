using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet] // listelemek için
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetList();
            return Ok(values); // Burada genellikle bir liste döndürülür, örneğin: return Ok(TestimonialList); return view gibi
        }

        [HttpPost] // eklemek için
        public IActionResult TestimonialAdd(Testimonial testimonial)
        {
            // Burada genellikle bir model alırsınız ve onu eklemek için kullanırsınız.
            // Örneğin:
            _testimonialService.TInsert(testimonial);

            return Ok();
        }


        [HttpDelete] // silmek için
        public IActionResult TestimonialDelete(int id)
        {
            // Silme işlemi için genellikle bir id alırsınız.

            var result = _testimonialService.TGetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _testimonialService.TDelete(result);
            return Ok();
        }

        [HttpPut] // güncellemek için
        public IActionResult TestimonialUpdate(Testimonial testimonial)
        {
            // Güncelleme işlemi için genellikle bir model alırsınız.
            _testimonialService.TUpdate(testimonial);

            return Ok();
        }


        [HttpGet("{id}")] // İdye göre getirmek için
        public IActionResult GetTestimonial(int id)
        {
            // İdye göre bir Testimonial bilgisi almak için genellikle bir id alırsınız.
            var result = _testimonialService.TGetById(id);
            return Ok(result);
        }
    }
}
