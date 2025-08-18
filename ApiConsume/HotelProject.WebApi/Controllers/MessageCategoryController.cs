using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _messageCategory;

        public MessageCategoryController(IMessageCategoryService messageCategory)
        {
            _messageCategory = messageCategory;
        }

        [HttpGet] // listelemek için
        public IActionResult MessageList()
        {
            var values = _messageCategory.TGetList();
            return Ok(values); // Burada genellikle bir liste döndürülür, örneğin: return Ok(MessageList); return view gibi
        }

        [HttpPost] // eklemek için
        public IActionResult MessageAdd(MessageCategory message)
        {
            // Burada genellikle bir model alırsınız ve onu eklemek için kullanırsınız.
            // Örneğin:
            _messageCategory.TInsert(message);

            return Ok();
        }


        [HttpDelete("{id}")] // silmek için
        public IActionResult MessageDelete(int id)
        {
            // Silme işlemi için genellikle bir id alırsınız.

            var result = _messageCategory.TGetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _messageCategory.TDelete(result);
            return Ok();
        }

        [HttpPut] // güncellemek için
        public IActionResult MessageUpdate(MessageCategory message)
        {
            // Güncelleme işlemi için genellikle bir model alırsınız.
            _messageCategory.TUpdate(message);

            return Ok();
        }


        [HttpGet("{id}")] // İdye göre getirmek için
        public IActionResult GetMessage(int id)
        {
            // İdye göre bir Message bilgisi almak için genellikle bir id alırsınız.
            var result = _messageCategory.TGetById(id);
            return Ok(result);
        }
    }
}
