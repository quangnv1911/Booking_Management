using System;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public long? HomestayFeatureId { get; set; }

        public virtual HomstayFeature? HomestayFeature { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
