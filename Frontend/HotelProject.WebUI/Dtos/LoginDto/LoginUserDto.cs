using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Kullanıcı adını girmeyi unutmayınız")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Şifrenizi girmeyi unutmayınız")]
        public string? Password { get; set; }
    }
}
