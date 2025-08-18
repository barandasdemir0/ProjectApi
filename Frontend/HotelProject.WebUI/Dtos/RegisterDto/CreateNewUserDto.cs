using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Adınızı Giriniz")]
        public string? Name { get; set; }


        [Required(ErrorMessage ="SoyAdınızı Giriniz")]
        public string? SurName { get; set; }



        [Required(ErrorMessage ="Kullanıcı Adınızı Giriniz")]
        public string? UserName { get; set; }


        [Required(ErrorMessage ="Mailinizi Giriniz")]
        public string? Mail { get; set; }



        [Required(ErrorMessage ="Şifrenizi Giriniz")]
        public string? Password { get; set; }

        [Required(ErrorMessage ="Şifrenizi Tekrar Giriniz")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string? ConfirmPassword { get; set; }


        public int WorkLocationID { get; set; }




    }
}
