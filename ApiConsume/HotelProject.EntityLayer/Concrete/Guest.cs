using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Guest
    {
        public int GuestID { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Kimlik numarası 11 haneli olmalıdır.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "TC Kimlik numarası sadece rakamlardan oluşmalıdır.")]
        public string? IdentityNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? City { get; set; }
        public string? Telephone { get; set; }
        public string? Mail { get; set; }
    }
}
