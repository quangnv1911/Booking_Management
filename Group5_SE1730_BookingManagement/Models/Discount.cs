using System;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Models
{
    public partial class Discount
    {
        public Discount()
        {
            Invoices = new HashSet<Invoice>();
            Rooms = new HashSet<Room>();
        }

        public long Id { get; set; }
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? MaxUser { get; set; }
        public int? CurrentUses { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
