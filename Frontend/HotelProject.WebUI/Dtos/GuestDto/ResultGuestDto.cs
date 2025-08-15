using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.GuestDto
{
    public class ResultGuestDto
    {
        public int GuestID { get; set; }
        public string? IdentityNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? City { get; set; }
        public string? Telephone { get; set; }
        public string? Mail { get; set; }
    }
}
