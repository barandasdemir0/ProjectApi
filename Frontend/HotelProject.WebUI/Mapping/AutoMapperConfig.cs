using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using HotelProject.WebUI.Dtos.TestimonaiDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<CreateDtoService, Service>().ReverseMap();
            CreateMap<UpdateDtoService, Service>().ReverseMap();

            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();

            CreateMap<LoginUserDto, AppUser>().ReverseMap();

            CreateMap<UpdateAboutDto, About>().ReverseMap();
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<ResultAboutDto, About>().ReverseMap();

            CreateMap<ResultRoomDto, Room>().ReverseMap();
            CreateMap<CreateRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();

            CreateMap<ResultTestimonialDto,Testimonial>().ReverseMap();
            CreateMap<CreateTestimonialDto,Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto,Testimonial>().ReverseMap();

            CreateMap<ResultStaffDto,Staff>().ReverseMap();
            CreateMap<CreateStaffDto,Staff>().ReverseMap();
            CreateMap<UpdateStaffDto,Staff>().ReverseMap();

            CreateMap<CreateSubscribeDto,Subscribe>().ReverseMap();
            CreateMap<ResultSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<UpdateSubscribeDto, Subscribe>().ReverseMap();


            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<UpdateBookingDto, Booking>().ReverseMap();
            CreateMap<ResultBookingDto, Booking>().ReverseMap();
            CreateMap<ApprovedReservationDto, Booking>().ReverseMap();

            CreateMap<CreateContactDto, Contact>().ReverseMap();

        }

    }
}
