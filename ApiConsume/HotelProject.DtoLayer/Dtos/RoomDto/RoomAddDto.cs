using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomAddDto
    {
        [Required(ErrorMessage ="Oda Numarasını Giriniz")]
        public string? RoomNumber { get; set; }
        public string? RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen Fiyat bilgisi Giriniz")]
        public int RoomPrice { get; set; }

        [Required(ErrorMessage = "Oda Başlığı Giriniz")]
        public string? RoomTitle { get; set; }

        [Required(ErrorMessage = "Oda Yatak Sayısı Giriniz")]
        public string? BedCount { get; set; }

        [Required(ErrorMessage = "Oda Banyo Sayısı Giriniz")]
        public string? BathCount { get; set; }
        public string? Wifi { get; set; }
        public string? RoomDescription { get; set; }
    }
}
