namespace HotelProject.WebUI.Dtos.BookingDto
{
    public class GetBookingList
    {
        public int BookingID { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerMail { get; set; }
        public string? Telephone { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string? AdultCount { get; set; }
        public string? ChildCount { get; set; }
        public string? RoomCount { get; set; }
        public string? SpecialRequest { get; set; }
        public string? Description { get; set; }
        public string? ChooseRoom { get; set; }
        public string? Status { get; set; }
    }
}
