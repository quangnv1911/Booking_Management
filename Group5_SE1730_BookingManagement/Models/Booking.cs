using System;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Models
{
    public partial class Booking
    {


        public long Id { get; set; }
        public long? HomestayId { get; set; }
        public string? GuestId { get; set; }
        public long? RoomId { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int? NumAdults { get; set; }
        public int? NumChildren { get; set; }
        public string? SpecialReq { get; set; }
        public bool? Status { get; set; }

        public virtual Guest? Guest { get; set; }
        public virtual Homestay? Homestay { get; set; }
        public virtual Room? Room { get; set; }
        public virtual Invoice? Invoices { get; set; }
    }
}
