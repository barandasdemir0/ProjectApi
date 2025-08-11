using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet] // listelemek için
        public IActionResult RoomList()
        {
            var values = _roomService.TGetList();
            return Ok(values); // Burada genellikle bir liste döndürülür, örneğin: return Ok(StaffList); return view gibi
        }

        [HttpPost] // eklemek için
        public IActionResult RoomAdd(Room room)
        {
            // Burada genellikle bir model alırsınız ve onu eklemek için kullanırsınız.
            // Örneğin:
            _roomService.TInsert(room);

            return Ok();
        }


        [HttpDelete] // silmek için
        public IActionResult RoomDelete(int id)
        {
            // Silme işlemi için genellikle bir id alırsınız.

            var result = _roomService.TGetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _roomService.TDelete(result);
            return Ok();
        }

        [HttpPut] // güncellemek için
        public IActionResult RoomUpdate(Room room)
        {
            // Güncelleme işlemi için genellikle bir model alırsınız.
            _roomService.TUpdate(room);

            return Ok();
        }


        [HttpGet("{id}")] // İdye göre getirmek için
        public IActionResult GetRoom(int id)
        {
            // İdye göre bir staff bilgisi almak için genellikle bir id alırsınız.
            var result = _roomService.TGetById(id);
            return Ok(result);
        }

    }
}
