namespace HotelProject.WebUI.Dtos.RoomDto
{
    public class ResultRoomDto
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
