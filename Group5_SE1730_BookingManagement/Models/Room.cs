using System;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
            Reviews = new HashSet<Review>();
            Discounts = new HashSet<Discount>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public int? MaxGuests { get; set; }
        public long? RoomTypeId { get; set; }
        public long? HomestayId { get; set; }
        public decimal? Price { get; set; }

        public bool? Status { get; set; }
        public string? Img { get; set; }
        public virtual Homestay? Homestay { get; set; }
        public virtual RoomType? RoomType { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Discount> Discounts { get; set; }
    }
}
