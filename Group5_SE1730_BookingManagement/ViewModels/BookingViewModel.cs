namespace Group5_SE1730_BookingManagement.ViewModels
{
    public class BookingViewModel
    {
        public long Id { get; set; }
        public string GuestName { get; set; }
        public string HomestayName { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int? NumAdults { get; set; }
        public int? NumChildren { get; set; }
        public string? SpecialReq { get; set; }
        public bool? Status { get; set; }
    }
}
