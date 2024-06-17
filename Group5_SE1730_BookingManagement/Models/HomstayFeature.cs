using System;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Models
{
    public partial class HomstayFeature
    {
        public HomstayFeature()
        {
            RoomTypes = new HashSet<RoomType>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<RoomType> RoomTypes { get; set; }
    }
}
