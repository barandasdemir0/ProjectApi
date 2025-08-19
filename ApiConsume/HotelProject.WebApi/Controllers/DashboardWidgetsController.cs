using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;

        public DashboardWidgetsController(IStaffService staffService, IBookingService bookingService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }

        [HttpGet("StaffCount")]
        public IActionResult StaffCount()
        {
            var staffCount = _staffService.TGetStaffCount();
            return Ok(staffCount);
        }

        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var booking = _bookingService.TGetBookingCount();
            return Ok(booking);
        }

        [HttpGet("AppuserCount")]
        public IActionResult AppuserCount()
        {
            var appuser = _appUserService.TAppUserCount();
            return Ok(appuser);
        }

        [HttpGet("RoomCount")]
        public IActionResult RoomCount()
        {
            var room = _roomService.TRoomCount();
            return Ok(room);
        }
    }
}
