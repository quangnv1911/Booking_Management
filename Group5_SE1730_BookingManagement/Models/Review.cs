using System;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Models
{
    public partial class Review
    {
        public long Id { get; set; }
        public string? GuestId { get; set; }
        public byte? Rating { get; set; }
        public long? ReviewText { get; set; }
        public long? RoomId { get; set; }

        public bool? Status { get; set; }

        public virtual Guest? Guest { get; set; }
        public virtual Room? Room { get; set; }
    }
}
