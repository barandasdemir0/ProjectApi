using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessage;

        public SendMessageController(ISendMessageService sendMessage)
        {
            _sendMessage = sendMessage;
        }

      

        [HttpGet] // listelemek için
        public IActionResult SendMessageList()
        {
            var values = _sendMessage.TGetList();
            return Ok(values); // Burada genellikle bir liste döndürülür, örneğin: return Ok(StaffList); return view gibi
        }

        [HttpPost] // eklemek için
        public IActionResult SendMessageAdd(SendMessage sendMessage)
        {
            // Burada genellikle bir model alırsınız ve onu eklemek için kullanırsınız.
            // Örneğin:
            sendMessage.Date = DateTime.Parse( DateTime.Now.ToShortDateString()); // Tarihi otomatik olarak güncelle
            _sendMessage.TInsert(sendMessage);

            return Ok();
        }


        [HttpDelete("{id}")] // silmek için
        public IActionResult SendMessageDelete(int id)
        {
            // Silme işlemi için genellikle bir id alırsınız.

            var result = _sendMessage.TGetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _sendMessage.TDelete(result);
            return Ok();
        }

        [HttpPut] // güncellemek için
        public IActionResult SendMessageUpdate(SendMessage sendMessage)
        {
            // Güncelleme işlemi için genellikle bir model alırsınız.
            _sendMessage.TUpdate(sendMessage);

            return Ok();
        }


        [HttpGet("{id}")] // İdye göre getirmek için
        public IActionResult GetSendMessage(int id)
        {
            // İdye göre bir staff bilgisi almak için genellikle bir id alırsınız.
            var result = _sendMessage.TGetById(id);
            return Ok(result);
        }


        [HttpGet("GetSendMessageCount")] // İdye göre getirmek için
        public IActionResult GetSendMessageCount()
        {
           
            return Ok(_sendMessage.TGetSendMessageCount());
        }
    }
}
