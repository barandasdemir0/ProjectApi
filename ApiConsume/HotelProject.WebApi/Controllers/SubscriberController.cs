using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private readonly ISubscribesService _subscribesService;

        public SubscriberController(ISubscribesService subscribesSubscriber)
        {
            _subscribesService = subscribesSubscriber;
        }

        [HttpGet] // listelemek için
        public IActionResult SubscriberList()
        {
            var values = _subscribesService.TGetList();
            return Ok(values); // Burada genellikle bir liste döndürülür, örneğin: return Ok(SubscriberList); return view gibi
        }

        [HttpPost] // eklemek için
        public IActionResult SubscriberAdd(Subscribe subscriber)
        {
            // Burada genellikle bir model alırsınız ve onu eklemek için kullanırsınız.
            // Örneğin:
            _subscribesService.TInsert(subscriber);

            return Ok();
        }


        [HttpDelete("{id}")] // silmek için
        public IActionResult SubscriberDelete(int id)
        {
            // Silme işlemi için genellikle bir id alırsınız.

            var result = _subscribesService.TGetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _subscribesService.TDelete(result);
            return Ok();
        }

        [HttpPut] // güncellemek için
        public IActionResult SubscriberUpdate(Subscribe subscriber)
        {
            // Güncelleme işlemi için genellikle bir model alırsınız.
            _subscribesService.TUpdate(subscriber);

            return Ok();
        }


        [HttpGet("{id}")] // İdye göre getirmek için
        public IActionResult GetSubscriber(int id)
        {
            // İdye göre bir Subscriber bilgisi almak için genellikle bir id alırsınız.
            var result = _subscribesService.TGetById(id);
            return Ok(result);
        }
    }
}
