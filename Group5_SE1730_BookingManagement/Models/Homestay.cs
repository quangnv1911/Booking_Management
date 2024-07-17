using System;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Models
{
    public partial class Homestay
    {
        public Homestay()
        {
            Bookings = new HashSet<Booking>();
            Rooms = new HashSet<Room>();
        }

        public long Id { get; set; }
        public string? HotelName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Rating { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? HotelImage { get; set; }
        public bool? Status { get; set; }

        public string? Img { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
