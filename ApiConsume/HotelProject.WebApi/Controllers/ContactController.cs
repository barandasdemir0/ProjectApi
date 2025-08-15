using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet] // listelemek için
        public IActionResult ContactList()
        {
            var values = _contactService.TGetList();
            return Ok(values); // Burada genellikle bir liste döndürülür, örneğin: return Ok(StaffList); return view gibi
        }

        [HttpPost] // eklemek için
        public IActionResult ContactAdd(Contact contact)
        {
            // Burada genellikle bir model alırsınız ve onu eklemek için kullanırsınız.
            // Örneğin:
            contact.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _contactService.TInsert(contact);

            return Ok();
        }


        [HttpDelete("{id}")] // silmek için
        public IActionResult ContactDelete(int id)
        {
            // Silme işlemi için genellikle bir id alırsınız.

            var result = _contactService.TGetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _contactService.TDelete(result);
            return Ok();
        }

        [HttpPut] // güncellemek için
        public IActionResult ContactUpdate(Contact contact)
        {
            // Güncelleme işlemi için genellikle bir model alırsınız.
            _contactService.TUpdate(contact);

            return Ok();
        }


        [HttpGet("{id}")] // İdye göre getirmek için
        public IActionResult GetContact(int id)
        {
            // İdye göre bir staff bilgisi almak için genellikle bir id alırsınız.
            var result = _contactService.TGetById(id);
            return Ok(result);
        }
    }
}
