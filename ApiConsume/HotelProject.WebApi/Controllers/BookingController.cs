using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet] // listelemek için
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values); // Burada genellikle bir liste döndürülür, örneğin: return Ok(StaffList); return view gibi
        }

        [HttpPost] // eklemek için
        public IActionResult BookingAdd(Booking booking)
        {
            // Burada genellikle bir model alırsınız ve onu eklemek için kullanırsınız.
            // Örneğin:
            _bookingService.TInsert(booking);

            return Ok();
        }


        [HttpDelete("{id}")] // silmek için
        public IActionResult BookingDelete(int id)
        {
            // Silme işlemi için genellikle bir id alırsınız.

            var result = _bookingService.TGetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _bookingService.TDelete(result);
            return Ok();
        }

        [HttpPut] // güncellemek için
        public IActionResult BookingUpdate(Booking booking)
        {
            // Güncelleme işlemi için genellikle bir model alırsınız.
            _bookingService.TUpdate(booking);

            return Ok();
        }


        [HttpGet("{id}")] // İdye göre getirmek için
        public IActionResult GetBooking(int id)
        {
            // İdye göre bir staff bilgisi almak için genellikle bir id alırsınız.
            var result = _bookingService.TGetById(id);
            return Ok(result);
        }
    }
}
