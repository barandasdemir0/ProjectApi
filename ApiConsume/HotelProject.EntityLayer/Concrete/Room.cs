using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Room
    {
        public int RoomID { get; set; }
        public string? RoomNumber { get; set; }
        public string? RoomCoverImage { get; set; }
        public int RoomPrice { get; set; }
        public string? RoomTitle { get; set; }
        public string? BedCount { get; set; }
        public string? BathCount { get; set; }
        public string? Wifi { get; set; }
        public string? RoomDescription { get; set; }
    }
}
